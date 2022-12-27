using AppKi.Business.Services.Models;
using AppKi.Commons.Enums;
using AppKi.Commons.Models;
using AppKi.Exchanges;
using Microsoft.Extensions.Logging;

namespace AppKi.Business.Services.Internals;

internal class DataFeedService : IDataFeedService
{
    private readonly Random _random = Random.Shared;
    private readonly IExchangeFactory _exchangeFactory;
    private readonly ILogger<DataFeedService> _logger;

    public DataFeedService(IExchangeFactory exchangeFactory, ILogger<DataFeedService> logger)
    {
        _exchangeFactory = exchangeFactory;
        _logger = logger;
    }

    public async Task<PagedResult<SymbolDto>> GetSymbols(GetSymbolsRequest request, CancellationToken token = default)
    {
        await Task.Yield();
        return PagedResult<SymbolDto>.Ok(new List<SymbolDto>
        {
            new("ETH", "USDT", "ETH-USDT", ExchangeProvider.Kucoin, (decimal) _random.NextDouble(),
                (decimal) _random.NextDouble()),
            new("ETH", "USDC", "ETH-USDC", ExchangeProvider.Kucoin, (decimal) _random.NextDouble(),
                (decimal) _random.NextDouble()),
            new("ETH", "USDT", "ETH-USDT", ExchangeProvider.GateIo, (decimal) _random.NextDouble(),
                (decimal) _random.NextDouble()),
            new("ETH", "USDT", "ETHUST", ExchangeProvider.Bitfinex, (decimal) _random.NextDouble(),
                (decimal) _random.NextDouble()),
            new("ETH", "USDT", "ETH-USDT", ExchangeProvider.Bittrex, (decimal) _random.NextDouble(),
                (decimal) _random.NextDouble()),
        }, request.count, request.page, 5);
    }

    public async IAsyncEnumerable<OhlcvDto> GetOhlcv(GetOhlcvRequest request, CancellationToken token = default)
    {
        var previousClose = 0d;
        // var exchange = _exchangeFactory.GetExchangeByType(request.Exchange);

        while (!token.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500), token);
            var item = GetRandomOhlcv(previousClose);
            previousClose = item.Close;
            yield return item;
        }
    }

    private OhlcvDto GetRandomOhlcv(double close)
    {
        var set = Enumerable.Range(0, 5).Select(_ => _random.NextDouble()).OrderBy(e => e).ToArray();

        return new OhlcvDto(close == 0 ? set[0] : close, set[1], set[2], set[3], set[4] * 100000);
    }
}