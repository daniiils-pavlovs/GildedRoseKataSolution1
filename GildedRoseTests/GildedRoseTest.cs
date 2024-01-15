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

        [Fact]
        public void UpdateQuality_IncreasesQualityBy2ForAgedBrie_WhenSellInIsNegative()
        {
            // Arrange
            var agedBrie = new Item { Name = "Aged Brie", SellIn = -1, Quality = 10 };
            var gildedRose = new GildedRose(new List<Item> { agedBrie });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.Equal(12, agedBrie.Quality);
        }

        [Fact]
        public void UpdateQuality_IncreasesQualityForBackstagePasses_WithMoreThan10Days()
        {
            // Arrange
            var backstagePasses = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 10 };
            var gildedRose = new GildedRose(new List<Item> { backstagePasses });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.Equal(11, backstagePasses.Quality);
        }

        [Fact]
        public void UpdateQuality_IncreasesQualityForBackstagePasses_With10DaysOrLess()
        {
            // Arrange
            var backstagePasses = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 };
            var gildedRose = new GildedRose(new List<Item> { backstagePasses });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.Equal(12, backstagePasses.Quality);
        }

        [Fact]
        public void UpdateQuality_IncreasesQualityForBackstagePasses_With5DaysOrLess()
        {
            // Arrange
            var backstagePasses = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 };
            var gildedRose = new GildedRose(new List<Item> { backstagePasses });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.Equal(13, backstagePasses.Quality);
        }

        [Fact]
        public void UpdateQuality_DropsQualityToZeroForBackstagePasses_AfterConcert()
        {
            // Arrange
            var backstagePasses = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 };
            var gildedRose = new GildedRose(new List<Item> { backstagePasses });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.Equal(0, backstagePasses.Quality);
        }
       
        [Fact]
        public void UpdateQuality_ItemQualitySetTo50_WhenIncreasedOver50()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 50 };
            var gildedRose = new GildedRose(new List<Item> { item });

            // Act
            gildedRose.UpdateQuality();
            Assert.Equal(50, item.Quality);

        }

        [Fact]
        public void UpdateQuality_ItemQualityIs0_CantDecreaseFurther()
        {
            // Arrange
            var normalItem = new Item { Name = "Some Item", SellIn = 5, Quality = 0 };
            var gildedRose = new GildedRose(new List<Item> { normalItem });

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.Equal(0, normalItem.Quality);
        }


    }

}
