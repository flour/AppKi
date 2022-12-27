using AppKi.Business.Hubs.Models;
using Microsoft.AspNetCore.SignalR;

namespace AppKi.Business.Hubs;

public interface IPublicHub
{
    IAsyncEnumerable<TickerDto> Stocks(StocksFilter filter, CancellationToken token);
}

public class PublicHub : Hub<IPublicHub>
{
}