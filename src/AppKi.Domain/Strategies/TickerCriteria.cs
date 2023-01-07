namespace AppKi.Domain.Strategies;

public class TickerCriteria
{
    public int RateDiff24H { get; set; }
    public int BetweenOrdersDiff { get; set; }
    public int RateDiff15M { get; set; }
    public decimal MinAmountInUsd { get; set; }
    public int Limit { get; set; }
    public int TradesLimit { get; set; }
}