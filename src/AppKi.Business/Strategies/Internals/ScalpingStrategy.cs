using AppKi.Commons.Enums;
using AppKi.Domain.Strategies;
using AppKi.Domain.Tables;
using AppKi.Exchanges;
using AppKi.Exchanges.Models;

namespace AppKi.Business.Strategies.Internals;

public class ScalpingStrategy : BaseTradeStrategy
{
    public override TradeStrategyType Type => TradeStrategyType.Scalping;

    public ScalpingStrategy(IExchange exchange) : base(exchange)
    {
    }

    public override Task<List<TickerInfo>> FindTickers(TickerCriteria findCriteria, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public override Task Run(StrategySettings settings, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}