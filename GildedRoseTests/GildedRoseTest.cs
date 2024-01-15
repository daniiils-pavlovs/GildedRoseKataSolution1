using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTests
    {
        [Fact]
        public void UpdateQuality_DecreasesQualityForNormalItem()
        {
            // Arrange
            var normalItem = new Item { Name = "Some Item", SellIn = 5, Quality = 10 };
            var gildedRose = new GildedRose(new List<Item> { normalItem });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.Equal(9, normalItem.Quality);
        }

        [Fact]
        public void UpdateQuality_IncreasesQualityForAgedBrie()
        {
            // Arrange
            var agedBrie = new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 };
            var gildedRose = new GildedRose(new List<Item> { agedBrie });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.Equal(11, agedBrie.Quality);
        }
    }

}
