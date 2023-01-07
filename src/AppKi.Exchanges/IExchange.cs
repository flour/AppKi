using AppKi.Commons.Enums;
using AppKi.Commons.Models;
using AppKi.Exchanges.Models;

namespace AppKi.Exchanges;

public interface IExchange : IDisposable
{
    ExchangeProvider Exchange { get; }
    ValueTask<ResultList<TickerInfo>> GetPairInfos(int limit = 2000, int tradesLimit = 100);
    ValueTask<Result<OrderBook>> GetOrderBook(int depth = 100);
    ValueTask<ResultList<PairData>> GetMyOrders(string ticker = null);
    ValueTask<Result> CancelOrder(string activeOrderId);
    ValueTask<Result<OrderDetails>> PlaceLimitOrder(OrderParams order);
}