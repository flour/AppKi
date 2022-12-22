using AppKi.Commons.Enums;

namespace AppKi.Exchanges.Internals;

internal class ExchangerFactory : IExchangeFactory
{
    private readonly IEnumerable<IExchange> _exchanges;

    public ExchangerFactory(IEnumerable<IExchange> exchanges)
    {
        _exchanges = exchanges;
    }

    public IExchange GetExchangeByType(ExchangeProvider exchangeProvider)
    {
        return _exchanges.FirstOrDefault(e => e.Exchange == exchangeProvider);
    }

    public List<IExchange> GetAll()
    {
        return _exchanges.ToList();
    }
}