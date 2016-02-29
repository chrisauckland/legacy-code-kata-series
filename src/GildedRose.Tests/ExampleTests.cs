using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class ExampleTests
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
    }
}