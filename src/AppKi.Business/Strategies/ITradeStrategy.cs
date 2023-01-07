using AppKi.Commons.Enums;
using AppKi.Commons.Models;
using AppKi.Domain.Strategies;
using AppKi.Exchanges;
using AppKi.Exchanges.Models;

namespace AppKi.Business.Strategies;

public abstract class BaseTradeStrategy
{
    protected IExchange _exchange;

    public BaseTradeStrategy(IExchange exchange)
    {
        _exchange = exchange;
    }

    public abstract TradeStrategyType Type { get; }
    public abstract Task<List<TickerInfo>> FindTickers(TickerCriteria findCriteria, CancellationToken token = default);
    public abstract Task<Result> Run(StrategySettings settings, CancellationToken token = default);
}