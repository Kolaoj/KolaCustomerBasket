using System.Collections.Generic;

namespace CustomerBasket.Core.DiscountCalculators
{
    public interface IDiscountCalculator
    {
        public double CalculateDiscount(IEnumerable<Item> items);
    }
}
