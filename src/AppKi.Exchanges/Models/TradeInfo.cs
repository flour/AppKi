using AppKi.Commons.Enums;

namespace AppKi.Exchanges.Models;

public class TradeInfo
{
    public string Id { get; init; }

    public DateTime Date { get; init; }

    public Side Side { get; init; }
    public OrderType Type { get; init; }
    public decimal Rate { get; init; }
    public decimal Amount { get; init; }
    public decimal AmountInUSD { get; init; }
}