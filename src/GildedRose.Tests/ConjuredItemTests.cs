using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class ConjuredItemTests
    {
        [Test]
        public void ConjuredItemsDegradeByTwoEachIteration()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "Conjured Item", SellIn = 10, Quality = 10}
                }

            };

            app.UpdateQuality();

            Assert.AreEqual(8, app.Items[0].Quality);
        }
    }
}