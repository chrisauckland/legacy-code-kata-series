using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class NormalItemTests
    {
        [Test]
        public void NormalItemsDegradeByOneEachIteration()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "Normal Item", SellIn = 10, Quality = 10}
                }

            };

            app.UpdateQuality();

            Assert.AreEqual(9,app.Items[0].Quality);
        }

        [Test]
        public void NormalItemsQualityNormallyWhenSellInIsAtOne()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "Normal Item", SellIn = 1, Quality = 10}
                }

            };

            app.UpdateQuality();
            Assert.AreEqual(9, app.Items[0].Quality);
        }

        [Test]
        public void NormalItemsQualityDegradesTwiceAsFastWhenPastSellInDate()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "Normal Item", SellIn = 0, Quality = 10}
                }

            };

            app.UpdateQuality();
            Assert.AreEqual(8, app.Items[0].Quality);
        }

        [Test]
        public void QualityCannotBeANegativeNumber()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "Normal Item", SellIn = 10, Quality = 0}
                }

            };

            app.UpdateQuality();
            Assert.AreEqual(0, app.Items[0].Quality);
        }
    }
}