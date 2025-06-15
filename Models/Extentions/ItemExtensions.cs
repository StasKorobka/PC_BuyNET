 
using System.Globalization;

namespace PC_BuyNET.Models
{
    public static class ItemExtensions
    {
        public static string FormatAsUSD(this decimal price)
        {
            return price.ToString("C", new CultureInfo("en-US"));
        }
    }
}
