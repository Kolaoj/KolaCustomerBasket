using System;
using System.Collections.Generic;
using CustomerBasket.Core.DiscountCalculators;
using CustomerBasket.Core.Items;
using NUnit.Framework;

namespace CustomerBasket.Core
{
    public class CustomerBasketTests
    {
        private readonly Item _bread = new Bread();
        private readonly Item _butter = new Butter();
        private readonly Item _milk = new Milk();
        private List<Item> _basketItems;

        private CustomerBasketCalculator _basketCalculator;

        private IDiscountCalculator _twoButterOneBreadDiscount;
        private IDiscountCalculator _fourMilksDiscount;
        private List<IDiscountCalculator> _discountCalculators;

        [SetUp]
        public void SetUp()
        {
            _basketItems = new List<Item>();

            _twoButterOneBreadDiscount = new TwoButtersOneBreadDiscount();
            _fourMilksDiscount = new FourMilksDiscount();

            _discountCalculators = new List<IDiscountCalculator> {_twoButterOneBreadDiscount, _fourMilksDiscount};

            _basketCalculator = new CustomerBasketCalculator(_discountCalculators);
        }

        [Test]
        public void OneBreadOneButterAndOneMilkInABasketShouldTotalTheCorrectAmount()
        {
            _basketItems.Add(_bread);
            _basketItems.Add(_butter);
            _basketItems.Add(_milk);

            var (total, savings) = _basketCalculator.CalculateBasket(_basketItems);

            Assert.AreEqual("�2.95", total);
            Assert.AreEqual("Savings made: �0.00", savings);
        }

        [Test]
        public void TwoButtersAndTwoBreadsInABasketShouldTotalTheCorrectAmountWithADiscount()
        {
            _basketItems.Add(_bread);
            _basketItems.Add(_bread);
            _basketItems.Add(_butter);
            _basketItems.Add(_butter);

            var (total, savings) = _basketCalculator.CalculateBasket(_basketItems);

            Assert.AreEqual("�3.10", total);
            Assert.AreEqual("Savings made: �0.50", savings);
        }

        //Extra test to make sure Two butter logic works correctly
        [Test]
        public void FourButtersAndFourBreadsInABasketShouldTotalTheCorrectAmountWithADiscount()
        {
            _basketItems.Add(_bread);
            _basketItems.Add(_bread);
            _basketItems.Add(_bread);
            _basketItems.Add(_bread);
            _basketItems.Add(_butter);
            _basketItems.Add(_butter);
            _basketItems.Add(_butter);
            _basketItems.Add(_butter);

            var (total, savings) = _basketCalculator.CalculateBasket(_basketItems);

            Assert.AreEqual("�6.20", total);
            Assert.AreEqual("Savings made: �1.00", savings);
        }

        [Test]
        public void FourMilksShouldTotalTheCorrectAmountWithADiscount()
        {
            _basketItems.Add(_milk);
            _basketItems.Add(_milk);
            _basketItems.Add(_milk);
            _basketItems.Add(_milk);

            var (total, savings) = _basketCalculator.CalculateBasket(_basketItems);

            Assert.AreEqual("�3.45", total);
            Assert.AreEqual("Savings made: �1.15", savings);
        }

        [Test]
        public void TwoButtersOneBreadAndEightMilksShouldTotalTheCorrectAmountWithADiscount()
        {
            _basketItems.Add(_butter);
            _basketItems.Add(_butter);
            _basketItems.Add(_bread);
            _basketItems.Add(_milk);
            _basketItems.Add(_milk);
            _basketItems.Add(_milk);
            _basketItems.Add(_milk);
            _basketItems.Add(_milk);
            _basketItems.Add(_milk);
            _basketItems.Add(_milk);
            _basketItems.Add(_milk);

            var (total, savings) = _basketCalculator.CalculateBasket(_basketItems);

            Assert.AreEqual("�9.00", total);
            Assert.AreEqual("Savings made: �2.80", savings);
        }
    }
}