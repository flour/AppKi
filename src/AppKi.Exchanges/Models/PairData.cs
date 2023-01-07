namespace AppKi.Exchanges.Models;

public class PairData
{
    public string Ticker { get; init; }

    public List<OrderDetails> ActiveOrders { get; init; }
}