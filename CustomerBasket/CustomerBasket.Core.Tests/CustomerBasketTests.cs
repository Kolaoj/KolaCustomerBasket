using System.Collections.Generic;
using NUnit.Framework;

namespace CustomerBasket.Core
{
    public class CustomerBasketTests
    {
        private readonly Item _bread = new Item {Name = "Bread", Price = 1.00};
        private readonly Item _butter = new Item {Name = "Butter", Price = 0.80};
        private readonly Item _milk = new Item {Name = "Milk", Price = 1.15};
        private List<Item> _itemsToAdd;
        private CustomerBasketCalculator _basketCalculator;


        [SetUp]
        public void SetUp()
        {
            _itemsToAdd = new List<Item>();
            _basketCalculator = new CustomerBasketCalculator();
        }

        [Test]
        public void OneBreadOneButterAndOneMilkInABasketShouldTotalTheCorrectAmount()
        {
            _itemsToAdd.Add(_bread);
            _itemsToAdd.Add(_butter);
            _itemsToAdd.Add(_milk);

            var total = _basketCalculator.CalculateBasket(_itemsToAdd);

            Assert.AreEqual("£2.95", total);
        }

        [Test]
        public void TwoButtersAndTwoBreadsInABasketShouldTotalTheCorrectAmountWithADiscount()
        {
            _itemsToAdd.Add(_bread);
            _itemsToAdd.Add(_bread);
            _itemsToAdd.Add(_butter);
            _itemsToAdd.Add(_butter);

            var total = _basketCalculator.CalculateBasket(_itemsToAdd);

            Assert.AreEqual("£3.10", total);
        }
    }
}