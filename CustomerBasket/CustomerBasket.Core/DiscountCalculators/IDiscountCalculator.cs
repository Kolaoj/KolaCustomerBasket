using System.Collections.Generic;
using CustomerBasket.Core.Items;

namespace CustomerBasket.Core.DiscountCalculators
{
    public interface IDiscountCalculator
    {
        public double CalculateDiscount(IEnumerable<Item> items);
    }
}
