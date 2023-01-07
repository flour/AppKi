using AppKi.Commons.Enums;

namespace AppKi.Exchanges.Models;

public class OrderDetails
{
    public string Id { get; init; }
    public string Ticker { get; init; }

    public DateTime Created { get; init; }

    public Side Side { get; init; }

    public OrderType Type { get; init; }

    public decimal Rate { get; init; }

    public decimal BaseAmount { get; init; }

    public decimal QuoteAmount { get; init; }

    public decimal Fee { get; init; }

    public string FeeCurrency { get; init; }

    public decimal FillPrice { get; init; }

    public decimal Filled { get; init; }
}