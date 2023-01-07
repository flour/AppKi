using System.Globalization;

namespace AppKi.Business.Helpers;

public class NumericHelper
{
    public static Task<decimal> GetStep(decimal rate)
    {
        var str = rate.ToString(CultureInfo.InvariantCulture).ToCharArray();
        var res = new char[str.Length];

        for (var i = str.Length - 1; i >= 0; i--)
        {
            if (str[i] != '0')
            {
                res[i] = '1';

                for (var j = i - 1; j >= 0; j--)
                {
                    if (char.IsDigit(str[j]))
                    {
                        res[j] = '0';
                        continue;
                    }

                    res[j] = str[j];
                }
                
                break;
            }

            res[i] = '0';
        }
        
        return Task.FromResult(decimal.Parse(new string(res), CultureInfo.InvariantCulture));
    }
}