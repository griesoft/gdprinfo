using System.Linq;
using NUnit.Framework;

namespace GdprInfo.Tests
{
    [TestFixture]
    public class GdprCountriesTests
    {
        [Test]
        public void Countries_ItemCount_ShouldMatchExpectedCount()
        {
            // Arrange
            var expectedCount = 28;

            // Act
            var count = GdprCountries.Countries.Count();

            // Assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void IsoCountryCodes_ShouldNot_ContainEmptyStrings()
        {
            // Act
            var containsEmptyStrings = GdprCountries.IsoCountryCodes.Any(code => string.IsNullOrEmpty(code));

            // Assert
            Assert.IsFalse(containsEmptyStrings);
        }

        [Test]
        public void LongCountryCodes_ShouldNot_ContainEmptyStrings()
        {
            // Act
            var containsEmptyStrings = GdprCountries.LongCountryCodes.Any(code => string.IsNullOrEmpty(code));

            // Assert
            Assert.IsFalse(containsEmptyStrings);
        }

        [Test]
        public void CountryNames_ShouldNot_ContainEmptyStrings()
        {
            // Act
            var containsEmptyStrings = GdprCountries.CountryNames.Any(code => string.IsNullOrEmpty(code));

            // Assert
            Assert.IsFalse(containsEmptyStrings);
        }

        [Test]
        public void CountryNumbers_ShouldNot_ContainEmptyStrings()
        {
            // Act
            var containsEmptyStrings = GdprCountries.CountryNumbers.Any(code => string.IsNullOrEmpty(code));

            // Assert
            Assert.IsFalse(containsEmptyStrings);
        }

        [Test]
        public void IsoCountryCodes_ShouldNot_ContainDuplicates()
        {
            // Act
            var containsDuplicates = GdprCountries.Countries.GroupBy(property => property.IsoCountryCode).Any(group => group.Count() > 1);

            // Assert
            Assert.IsFalse(containsDuplicates);
        }

        [Test]
        public void LongCountryCodes_ShouldNot_ContainDuplicates()
        {
            // Act
            var containsDuplicates = GdprCountries.Countries.GroupBy(property => property.LongCountryCode).Any(group => group.Count() > 1);

            // Assert
            Assert.IsFalse(containsDuplicates);
        }

        [Test]
        public void CountryNames_ShouldNot_ContainDuplicates()
        {
            // Act
            var containsDuplicates = GdprCountries.Countries.GroupBy(property => property.Name).Any(group => group.Count() > 1);

            // Assert
            Assert.IsFalse(containsDuplicates);
        }

        [Test]
        public void CountryNumbers_ShouldNot_ContainDuplicates()
        {
            // Act
            var containsDuplicates = GdprCountries.Countries.GroupBy(property => property.Number).Any(group => group.Count() > 1);

            // Assert
            Assert.IsFalse(containsDuplicates);
        }
    }
}
