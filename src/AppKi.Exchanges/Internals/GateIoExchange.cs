using AppKi.Commons.Enums;
using AppKi.Commons.Models;
using AppKi.Exchanges.Models;

namespace AppKi.Exchanges.Internals;

internal class GateIoExchange : IExchange
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public ExchangeProvider Exchange => ExchangeProvider.GateIo;
    
    public ValueTask<ResultList<TickerInfo>> GetPairInfos(int limit = 2000, int tradesLimit = 100)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<OrderBook>> GetOrderBook(int depth = 100)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ResultList<PairData>> GetMyOrders(string ticker = null)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result> CancelOrder(string activeOrderId)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<OrderDetails>> PlaceLimitOrder(OrderParams order)
    {
        throw new NotImplementedException();
    }
}