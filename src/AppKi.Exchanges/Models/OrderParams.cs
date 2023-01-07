using AppKi.Commons.Enums;

namespace AppKi.Exchanges.Models;

public class OrderParams
{
    public string Ticker { get; set; }
    public Side Side { get; set; }
    public decimal Price { get; set; }
    public decimal Amount { get; set; }
}