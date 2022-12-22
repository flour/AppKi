using AppKi.Commons.Enums;
using AppKi.Exchanges;

namespace AppKi.Business.Strategies.Internals;

internal class StrategyProcessor
{
    private List<BaseTradeStrategy> _strategies;
    private readonly IExchangeFactory _exchangeFactory;

    public StrategyProcessor(IExchangeFactory exchangeFactory)
    {
        _exchangeFactory = exchangeFactory;
        _strategies = new List<BaseTradeStrategy>();
    }

    public void CreateStrategy(ExchangeProvider exchangeProvider)
    {
        var exchange = _exchangeFactory.GetExchangeByType(exchangeProvider);
        var str = new ScalpingStrategy(exchange);
    }
}