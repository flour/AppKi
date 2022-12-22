using AppKi.Commons.Enums;
using AppKi.Domain.Strategies;
using AppKi.Domain.Tables;
using AppKi.Exchanges;
using AppKi.Exchanges.Models;

namespace AppKi.Business.Strategies;

public abstract class BaseTradeStrategy
{
    private IExchange _exchange;

    public BaseTradeStrategy(IExchange exchange)
    {
        _exchange = exchange;
    }

    public abstract TradeStrategyType Type { get; }
    public abstract Task<List<TickerInfo>> FindTickers(TickerCriteria findCriteria, CancellationToken token = default);
    public abstract Task Run(StrategySettings settings, CancellationToken token = default);
}