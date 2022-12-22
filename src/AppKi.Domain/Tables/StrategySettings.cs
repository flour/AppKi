﻿using System.ComponentModel.DataAnnotations;

namespace AppKi.Domain.Tables;

public class StrategySettings : BaseEntity<int>
{
    public string Ticker { get; set; }
    [Range(typeof(int), "1", "100")] public int SpendAmountPercent { get; set; }
    [Range(0, double.PositiveInfinity)] public decimal SpendAmountInUsd { get; set; }
    [Range(0, double.PositiveInfinity)] public decimal StopLoss { get; set; }
    [Range(0, double.PositiveInfinity)] public decimal TakeProfit { get; set; }
}