using System;
using System.Collections.Generic;
using System.Linq;

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
                if (item.Name.Equals("Butter", StringComparison.CurrentCultureIgnoreCase))
                {
                    butterCounter++;
                    noOfButters.Add(butterCounter);
                }
                else if (item.Name.Equals("Bread", StringComparison.CurrentCultureIgnoreCase))
                {
                    listOfBreads.Add(item);
                }
            }

            var noOfAvailableDiscount = noOfButters.Count(butterCount => butterCount % 2 == 0);

            foreach (var bread in listOfBreads)
            {
                if (noOfAvailableDiscount != 0)
                {
                    priceDeduction += bread.Price / 2;
                    noOfAvailableDiscount--;
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
