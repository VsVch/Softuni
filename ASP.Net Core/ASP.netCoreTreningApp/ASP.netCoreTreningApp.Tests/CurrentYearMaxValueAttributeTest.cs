using ASP.netCoreTreningApp.ValidationAttributes;
using System;
using Xunit;

namespace ASP.netCoreTreningApp.Tests
{
    public class CurrentYearMaxValueAttributeTest
    {
        [Fact]
        public void IsValidReturnFauseForYearAfterCurrentyear()
        {
            var attribute = new CurrentYearMaxValueAttribute(1982);

            var isValid = attribute.IsValid(DateTime.UtcNow.AddYears(1));

            Assert.False(isValid);
        }
    }
}
