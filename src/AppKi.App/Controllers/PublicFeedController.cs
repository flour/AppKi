using AppKi.Business.Features.PublicData;
using AppKi.Business.Hubs.Models;
using AppKi.Business.Services.Models;
using AppKi.Commons.Models;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace AppKi.App.Controllers;

[ApiController]
[Route("[controller]")]
public class PublicFeedController : ControllerBase
{
    private readonly IMediator _mediator;

    public PublicFeedController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("stocks")]
    public async Task<PagedResult<SymbolDto>> GetStocks(
        [FromQuery] PageContext<StocksFilter> filter, CancellationToken token)
        => await _mediator.Send(new GetStocksQuery(filter), token);
}