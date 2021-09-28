using System;
using System.Collections.Generic;
using System.Linq;
using CustomerBasket.Core.Items;

namespace CustomerBasket.Core.DiscountCalculators
{
    public class TwoButtersOneBreadDiscount : IDiscountCalculator
    {
        public double CalculateDiscount(IEnumerable<Item> items)
        {
            var noOfButters = new List<int>();
            var listOfBreads = new List<Item>();
            var priceDeduction = 0.00;
            var butterCounter = 0;

            foreach (var item in items)
            {
                if (item.GetType().Name.Equals("Butter", StringComparison.CurrentCultureIgnoreCase))
                {
                    butterCounter++;
                    noOfButters.Add(butterCounter);
                }
                else if (item.GetType().Name.Equals("Bread", StringComparison.CurrentCultureIgnoreCase))
                {
                    listOfBreads.Add(item);
                }
            }

            var noOfAvailableDiscounts = noOfButters.Count(butterCount => butterCount % 2 == 0);

            foreach (var bread in listOfBreads)
            {
                if (noOfAvailableDiscounts != 0)
                {
                    priceDeduction += bread.Price / 2;
                    noOfAvailableDiscounts--;
                }
                else
                {
                    break;
                }
            }

            return priceDeduction;
        }
    }
}
