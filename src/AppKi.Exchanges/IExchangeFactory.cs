using AppKi.Commons.Enums;

namespace AppKi.Exchanges;

public interface IExchangeFactory
{
    IExchange GetExchangeByType(ExchangeProvider exchangeProvider);
    List<IExchange> GetAll();
}