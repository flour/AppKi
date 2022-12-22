using AppKi.Business.Services.Models;
using AppKi.Commons.Models;

namespace AppKi.Business.Services;

public interface IDataFeedService
{
    Task<ResultList<SymbolDto>> GetSymbols(GetSymbolsRequest request, CancellationToken token = default);
    IAsyncEnumerable<OhlcvDto> GetOhlcv(GetOhlcvRequest request, CancellationToken token = default);
}