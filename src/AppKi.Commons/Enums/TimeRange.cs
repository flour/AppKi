using System.ComponentModel;

namespace AppKi.Commons.Enums;

public enum TimeRange
{
    [Description("")] None,
    [Description("1 minute")] Minutes1,
    [Description("5 minute")] Minutes5,
    [Description("15 minute")] Minutes15,
    [Description("30 minute")] Minutes30,
    [Description("1 hour")] Hour,
    [Description("2 hours")] Hour2,
    [Description("4 hours")] Hour4,
    [Description("8 hours")] Hour8,
    [Description("12 hours")] Hour12,
    [Description("1 day")] Day,
    [Description("1 week")] Week,
    [Description("1 month")] Month,
}