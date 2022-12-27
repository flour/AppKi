using AppKi.Business.Services.Models;

namespace AppKi.Business.Hubs.Models;

public record TickerDto(SymbolDto Symbol, OhlcvDto Ohlcv);