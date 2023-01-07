namespace AppKi.Exchanges.Models;

public class OrderBook
{
    public List<List<decimal>> Asks { get; init; }

    public List<List<decimal>> Bids { get; init; } 
}