using AppKi.Business.Features.References;
using AppKi.Business.Features.References.Models;
using AppKi.Commons.Models;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace AppKi.App.Controllers;

[ApiController]
[Route("[controller]")]
public class ReferencesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReferencesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("enum/{type}")]
    public async Task<ResultList<ReferenceTypeDto>> GetReference(string type, CancellationToken token)
        => await _mediator.Send(new GetEnumReferenceTypeQuery(type), token);
}