using AppKi.Commons.Enums;

namespace AppKi.Business.Services.Models;

// requests
public record GetSymbolsRequest(int count, int page, ExchangeProvider? Exchange = null);
public record GetOhlcvRequest(ExchangeProvider Exchange, string Symbol, TimeRange Range = TimeRange.Minutes30);

// responses


public record SymbolDto(
    string Base,
    string Quoted, 
    string ApiSymbol, 
    ExchangeProvider Exchange,
    decimal Bid,
    decimal Ask)
{
    public string Symbol => $"{Base} - {Quoted}";
}
public record OhlcvDto(double Open, double High, double Low, double Close, double Volume);