using AppKi.Commons.Enums;

namespace AppKi.Exchanges.Internals;

internal class InternalExchange : GateIoExchange
{
    public new ExchangeProvider Exchange => ExchangeProvider.Internal;
}