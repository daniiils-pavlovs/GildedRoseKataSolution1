using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            var normalItems = Items.Where(item => item.Name != "Aged Brie" 
                && item.Name != "Backstage passes to a TAFKAL80ETC concert"
                && item.Name != "Sulfuras, Hand of Ragnaros").ToList();
            foreach (var item in normalItems)
            {
                if (item.Quality > 0)
                    item.Quality = item.Quality - 1;
            }

            var specialItems = Items.Where(item => (item.Name == "Aged Brie"
                || item.Name == "Backstage passes to a TAFKAL80ETC concert") && item.Quality <50).ToList();
            foreach (var item in specialItems)
            {
                switch (item.Name) 
                {
                    case "Aged Brie":
                        item.Quality = item.Quality + 1;
                        break;

                    case "Backstage passes to a TAFKAL80ETC concert":
                        if (item.SellIn <= 5)
                        {
                            item.Quality += 3;
                            break;
                        }
                        if (item.SellIn <= 10)
                        {
                            item.Quality += 2;
                            break;
                        }
                        else
                        {
                            item.Quality += 1;
                        }
                        break;
                }

                if(item.Quality > 50)
                {
                    item.Quality = 50;
                }    
            }

            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
