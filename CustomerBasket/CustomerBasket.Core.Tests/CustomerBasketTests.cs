using System.Collections.Generic;
using NUnit.Framework;

namespace CustomerBasket.Core
{
    public class CustomerBasketTests
    {
        private readonly Item _bread = new Item { Name = "Bread", Price = 1.00 };
        private readonly Item _butter = new Item { Name = "Butter", Price = 0.80 };
        private readonly Item _milk = new Item { Name = "Milk", Price = 1.15 };
        private List<Item> _itemsToAdd;

        [Test]
        public void OneBreadOneButterAndOneMilkInABasketShouldTotalTheCorrectAmount()
        {
            _itemsToAdd = new List<Item> {_bread, _butter, _milk};

            var customerBasketCalculator = new CustomerBasketCalculator();

           var total = customerBasketCalculator.CalculateBasket(_itemsToAdd);

           Assert.AreEqual("£2.95", total);
        }
    }
}