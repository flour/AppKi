using AppKi.Commons.Enums;

namespace AppKi.Exchanges;

public interface IExchange : IDisposable
{
    ExchangeProvider Exchange { get; }
}