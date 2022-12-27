using AppKi.Commons.Enums;

namespace AppKi.Business.Hubs.Models;

public class StocksFilter
{
    public string Base { get; set; }
    public string Quoted { get; set; }
    public ExchangeProvider? Exchange { get; set; }
}