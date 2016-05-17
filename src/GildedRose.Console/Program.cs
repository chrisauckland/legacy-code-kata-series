using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    internal class Program
    {
        private IList<Item> Items;

        private const string c_AgedBrie = "Aged Brie";
        private const string c_BackstagePassesToConcert = "Backstage passes to a TAFKAL80ETC concert";
        private const string c_SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";

        internal static void Main(string[] args)
        {
            UpdateAndPrintItems();

            System.Console.ReadKey();
        }

        internal static void UpdateAndPrintItems()
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                }
            };

            app.UpdateItemsQuality();

            PrintItems(app);
        }

        private static void PrintItems(Program app)
        {
            foreach (var item in app.Items)
            {
                System.Console.WriteLine("{0}|{1}|{2}", item.Name, item.Quality, item.SellIn);
            }
        }

        public void UpdateItemsQuality()
        {
            UpdateItemsQuality(Items.ToArray());
        }

        public static void UpdateItemsQuality(Item[] items)
        {
            foreach (var item in items)
            {
                UpdateItemQuality(item);
            }
        }

        private static void UpdateItemQuality(Item item)
        {
            var name = item.Name;

            if (name == c_AgedBrie || name == c_BackstagePassesToConcert)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (name == c_BackstagePassesToConcert)
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }
            else
            {
                if (item.Quality > 0)
                {
                    if (name != c_SulfurasHandOfRagnaros)
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }

            if (name != c_SulfurasHandOfRagnaros)
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (name != c_AgedBrie)
                {
                    if (name != c_BackstagePassesToConcert)
                    {
                        if (item.Quality > 0)
                        {
                            if (name != c_SulfurasHandOfRagnaros)
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}