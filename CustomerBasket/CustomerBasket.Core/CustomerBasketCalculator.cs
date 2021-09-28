using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CustomerBasket.Core
{
    public class CustomerBasketCalculator
    {
        public string CalculateBasket(IEnumerable<Item> items)
        {
            var price = items.Sum(item => item.Price);

            return price.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}
