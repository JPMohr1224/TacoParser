using System;
using Xunit;
using System.Collections.Generic;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {

            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("33.283584, -86.855317, Taco Bell Helena...", -86.855317)]
        [InlineData("34.057823, -84.592806, Taco Bell Kennesaw...", -84.592806)]

        public void ShouldParseLongitude(string line, double expected)
        {
            var tacoParserObject = new TacoParser();

            var actual = tacoParserObject.Parse(line).Location.Longitude;

            Assert.Equal(expected, actual);
        }




        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("33.283584, -86.855317, Taco Bell Helena...", 33.283584)]
        [InlineData("34.057823, -84.592806, Taco Bell Kennesaw...", 34.057823)]

        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParserObject = new TacoParser();

            var actual = tacoParserObject.Parse(line).Location.Latitude;

            Assert.Equal(expected, actual);

        }
    }
}
