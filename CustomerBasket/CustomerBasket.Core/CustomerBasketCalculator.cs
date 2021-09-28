using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CustomerBasket.Core.DiscountCalculators;

namespace CustomerBasket.Core
{
    public class CustomerBasketCalculator
    {
        private readonly IEnumerable<IDiscountCalculator> _discountCalculators;

        public CustomerBasketCalculator(IEnumerable<IDiscountCalculator> discountCalculators)
        {
            _discountCalculators = discountCalculators;
        }

        public Tuple<string, string> CalculateBasket(List<Item> items)
        {
            var subTotalWithoutDiscounts = items.Sum(item => item.Price);

            var discountDeductions = _discountCalculators.Sum(discountCalculator => discountCalculator.CalculateDiscount(items));

            var savings = discountDeductions;

            var savingsMessage = $"Savings made: {savings.ToString("C", CultureInfo.CurrentCulture)}";

            var total = subTotalWithoutDiscounts - discountDeductions;

            var totalPriceWithCurrency = total.ToString("C", CultureInfo.CurrentCulture);

            var basketTotal = new Tuple<string, string>(totalPriceWithCurrency, savingsMessage);

            return basketTotal;
        }
    }
}
