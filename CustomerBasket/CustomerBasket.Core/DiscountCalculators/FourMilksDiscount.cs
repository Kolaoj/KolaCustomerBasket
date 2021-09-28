using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerBasket.Core.DiscountCalculators
{
    public class FourMilksDiscount : IDiscountCalculator
    {
        public double CalculateDiscount(IEnumerable<Item> items)
        {
            var priceDeduction = 0.00;
            var milkCounter = 0;
            var noOfMilks = new List<int>();
            var listOfMilks = new List<Item>();

            foreach (var item in items)
            {
                if (item.Name.Equals("Milk", StringComparison.CurrentCultureIgnoreCase))
                {
                    milkCounter++;
                    noOfMilks.Add(milkCounter);
                    listOfMilks.Add(item);
                }
            }

            var noOfAvailableDiscount = noOfMilks.Count(milkCount => milkCount % 4 == 0);

            foreach (var milk in listOfMilks.Where(milk => noOfAvailableDiscount != 0))
            {
                priceDeduction += milk.Price;
                noOfAvailableDiscount--;
            }

            return priceDeduction;
        }
    }
}
