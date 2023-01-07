namespace AppKi.Exchanges.Models;

public class TickerInfo
{
    public string Ticker { get; init; }

    public decimal Min24H { get; init; }
    public decimal Max24H { get; init; }

    public List<TradeInfo> LastTrades { get; init; }

    public decimal AmountInUSD { get; init; }
}