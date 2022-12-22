using AppKi.Commons.Enums;

namespace AppKi.Exchanges.Internals;

internal class GateIoExchange : IExchange
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public ExchangeProvider Exchange => ExchangeProvider.GateIo;
}