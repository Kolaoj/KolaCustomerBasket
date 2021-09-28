using System;
using System.Collections.Generic;
using System.Linq;
using CustomerBasket.Core.Items;

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
                if (item.GetType().Name.Equals("Milk", StringComparison.CurrentCultureIgnoreCase))
                {
                    milkCounter++;
                    noOfMilks.Add(milkCounter);
                    listOfMilks.Add(item);
                }
            }

            var noOfAvailableDiscounts = noOfMilks.Count(milkCount => milkCount % 4 == 0);

            foreach (var milk in listOfMilks.Where(milk => noOfAvailableDiscounts != 0))
            {
                priceDeduction += milk.Price;
                noOfAvailableDiscounts--;
            }

            return priceDeduction;
        }
    }
}
