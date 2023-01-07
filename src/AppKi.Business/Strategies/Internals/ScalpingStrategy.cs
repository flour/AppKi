using AppKi.Business.Helpers;
using AppKi.Commons.Enums;
using AppKi.Commons.Models;
using AppKi.Domain.Strategies;
using AppKi.Exchanges;
using AppKi.Exchanges.Models;

namespace AppKi.Business.Strategies.Internals;

public class ScalpingStrategy : BaseTradeStrategy
{
    public override TradeStrategyType Type => TradeStrategyType.Scalping;

    public ScalpingStrategy(IExchange exchange) : base(exchange)
    {
    }

    public override async Task<List<TickerInfo>> FindTickers(TickerCriteria findCriteria, CancellationToken token = default)
    {
        var now = DateTime.UtcNow;
        var result = new List<TickerInfo>();
        
        var exchangePairs = await _exchange.GetPairInfos(findCriteria.Limit, findCriteria.TradesLimit);

        exchangePairs.Data
            .Where(a => a.AmountInUSD >= findCriteria.MinAmountInUsd &&
                    a.Max24H - a.Min24H >= findCriteria.RateDiff24H)
            .ToList()
            .ForEach(tickerInfo => {
                var trades = tickerInfo.LastTrades
                .Where(t => t.Date > now.AddHours(-2))
                .ToList();

                if (!trades.Any())
                    return;
                
                var secDiffs = new List<int>();
                
                for (int i = 0, j = 1; j < trades.Count; i++, j++)
                {
                    var a = trades[i];
                    var b = trades[j];
                    
                    secDiffs.Add((int)(a.Date.Ticks - b.Date.Ticks) / 10000000);
                }
                
                if (secDiffs.Average(a => a) > findCriteria.BetweenOrdersDiff)
                    return;
                
                trades = trades.Where(t => t.Date > now.AddMinutes(-15)).ToList();
                
                var rateMin = trades.Min(t => t.Rate);
                var rateMax = trades.Max(t => t.Rate);
                
                if (rateMax - rateMin < findCriteria.RateDiff15M)
                    return;

                result.Add(tickerInfo); 
            });                                                     

        return result;
    }

    public override async Task<Result> Run(StrategySettings settings, CancellationToken token = default)
    {
        var orderBook = await _exchange.GetOrderBook();
        //1. Определение границ
        var askBorderTask = AnalyzeOrderBookSide(orderBook.Data.Asks, settings.Mul);
        var bidsBorderTask = AnalyzeOrderBookSide(orderBook.Data.Bids, settings.Mul);

        Task.WaitAll(new Task[] { askBorderTask, bidsBorderTask }, cancellationToken: token);

        var step = Math.Min(askBorderTask.Result.Step, bidsBorderTask.Result.Step);
        var sellPrice = askBorderTask.Result.Price - step;
        var buyPrice = bidsBorderTask.Result.Price + step;
        
        if (sellPrice == 0 || buyPrice == 0)
            return Result.Bad("Couldn't find sell or buy price.");
        //2. Определение ценовой разницы
        if (sellPrice - buyPrice <= settings.BordersDiff)
            return Result.Bad("Price diff is too small.");

        //3. Актуализация ордеров
        var pairsData = await _exchange.GetMyOrders(settings.Ticker);

        foreach (var pairData in pairsData.Data)
        foreach (var activeOrder in pairData.ActiveOrders)
        {
            if ((activeOrder.Side == Side.Buy && 
                    (activeOrder.Rate > sellPrice || activeOrder.Rate + step * settings.StepsCountToCancel < sellPrice)) || 
                activeOrder.Side == Side.Sell && 
                    (activeOrder.Rate < buyPrice || activeOrder.Rate - step * settings.StepsCountToCancel > buyPrice))
                await _exchange.CancelOrder(activeOrder.Id);
        }
        
        //4. Установка ордеров
        if (pairsData.Data.Any(a => a.ActiveOrders.Any()))
            pairsData = await _exchange.GetMyOrders(settings.Ticker);

        if (!pairsData.Data.Any(a => a.ActiveOrders.Any(o => o.Side == Side.Buy)))
            await PlaceOrder(settings, Side.Buy, sellPrice, askBorderTask.Result.Amount);
        if (!pairsData.Data.Any(a => a.ActiveOrders.Any(o => o.Side == Side.Buy)))
            await PlaceOrder(settings, Side.Sell, buyPrice, bidsBorderTask.Result.Amount);
        
        return Result.Ok();
    }

    private async Task PlaceOrder(StrategySettings settings, Side side, decimal price, decimal borderAmount)
    {
        var order = await _exchange.PlaceLimitOrder(new OrderParams
        {
            Ticker = settings.Ticker,
            Side = side,
            Price = price,
            Amount = borderAmount * 0.1m //10% 
        });
        throw new NotImplementedException();
    }

    private static async Task<BookSideAnalyzeResult> AnalyzeOrderBookSide(IReadOnlyList<List<decimal>> list, int mul)
    {
        var initAmount = list[0][1];
        var prevAmount = initAmount;
        
        for (var i = 1; i < list.Count; i++)
        {
            var curPrice = list[i][0];
            var curAmount = list[i][1];

            if (curAmount > initAmount * mul &&
                curAmount > prevAmount * mul)
            {
                var step = await NumericHelper.GetStep(curPrice);
                return new BookSideAnalyzeResult(curAmount, step, curAmount);
            }

            prevAmount = curAmount;
        }

        return  new BookSideAnalyzeResult(0m, 0m, 0m);
    }

    private class BookSideAnalyzeResult
    {
        public BookSideAnalyzeResult(decimal price, decimal step, decimal amount)
        {
            Price = price;
            Step = step;
            Amount = amount;
        }

        public decimal Price { get; }
        public decimal Step { get; }
        public decimal Amount { get; }
    }
}