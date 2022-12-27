using AppKi.Business.Hubs.Models;
using AppKi.Business.Services;
using AppKi.Business.Services.Models;
using AppKi.Commons.Models;
using Mediator;
using Microsoft.Extensions.Logging;

namespace AppKi.Business.Features.PublicData;

public class GetStocksQuery : IRequest<PagedResult<SymbolDto>>
{
    public PageContext<StocksFilter> Context { get; }

    public GetStocksQuery(PageContext<StocksFilter> context)
    {
        Context = context;
    }
}

public class GetStocksQueryHandler : IRequestHandler<GetStocksQuery, PagedResult<SymbolDto>>
{
    private readonly IDataFeedService _feedService;

    public GetStocksQueryHandler(IDataFeedService feedService)
    {
        _feedService = feedService;
    }

    public async ValueTask<PagedResult<SymbolDto>> Handle(GetStocksQuery request, CancellationToken cancellationToken)
    {
        return await _feedService.GetSymbols(new GetSymbolsRequest(
            request.Context.PageSize, request.Context.PageIndex, request.Context.Filter.Exchange), cancellationToken);
    }
}