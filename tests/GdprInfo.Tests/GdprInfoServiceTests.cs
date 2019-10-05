using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace GdprInfo.Tests
{
    [TestFixture]
    public class GdprInfoServiceTests
    {
        [Test]
        public void ConstructorTest()
        {
            // Arrange
            var mockDeviceCountryIdentifier = new Mock<IDeviceCountryIdentifier>(MockBehavior.Default);

            // Act
            var gdprInfoService = new GdprInfoService(mockDeviceCountryIdentifier.Object);

            // Assert
            Assert.IsNotNull(gdprInfoService);
        }

        [TestCaseSource(typeof(GdprInfoServiceTestsData), "IsDeviceInEeaOrUnknowTestCases")]
        public void IsDeviceInEeaOrUnknow_Always_ShouldReturnExpectedResult(string countryCode, bool expectedResult)
        {
            // Arrange
            var mockDeviceCountryIdentifier = new Mock<IDeviceCountryIdentifier>(MockBehavior.Strict);
            _ = mockDeviceCountryIdentifier.Setup(mock => mock.TryGetDeviceCountryCode()).Returns(countryCode);

            var gdprInfoService = new GdprInfoService(mockDeviceCountryIdentifier.Object);

            // Act
            var result = gdprInfoService.IsDeviceInEeaOrUnknow;

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));

            mockDeviceCountryIdentifier.VerifyAll();
        }

        [TestCase("ES", "ES")]
        [TestCase(null, null)]
        public void IsoCountryCode_Always_ReturnsExpectedResult(string countryCode, string? expectedResult)
        {
            // Arrange
            var mockDeviceCountryIdentifier = new Mock<IDeviceCountryIdentifier>(MockBehavior.Strict);
            _ = mockDeviceCountryIdentifier.Setup(mock => mock.TryGetDeviceCountryCode()).Returns(countryCode);

            var gdprInfoService = new GdprInfoService(mockDeviceCountryIdentifier.Object);

            // Act
            var result = gdprInfoService.IsoCountryCode;

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));

            mockDeviceCountryIdentifier.VerifyAll();
        }

        [TestCase("ES", "Spain")]
        [TestCase(null, null)]
        [TestCase("CA", null)]
        public void CountryName_Always_ReturnsExpectedResult(string countryCode, string? expectedResult)
        {
            // Arrange
            var mockDeviceCountryIdentifier = new Mock<IDeviceCountryIdentifier>(MockBehavior.Strict);
            _ = mockDeviceCountryIdentifier.Setup(mock => mock.TryGetDeviceCountryCode()).Returns(countryCode);

            var gdprInfoService = new GdprInfoService(mockDeviceCountryIdentifier.Object);

            // Act
            var result = gdprInfoService.CountryName;

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));

            mockDeviceCountryIdentifier.VerifyAll();
        }

        [TestCase("FR", "250")]
        [TestCase(null, null)]
        [TestCase("US", null)]
        public void CountryNumber_Always_ReturnsExpectedResult(string countryCode, string? expectedResult)
        {
            // Arrange
            var mockDeviceCountryIdentifier = new Mock<IDeviceCountryIdentifier>(MockBehavior.Strict);
            _ = mockDeviceCountryIdentifier.Setup(mock => mock.TryGetDeviceCountryCode()).Returns(countryCode);

            var gdprInfoService = new GdprInfoService(mockDeviceCountryIdentifier.Object);

            // Act
            var result = gdprInfoService.CountryNumber;

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));

            mockDeviceCountryIdentifier.VerifyAll();
        }

        [TestCase("GR", "GRC")]
        [TestCase(null, null)]
        [TestCase("US", null)]
        public void LongCountryCode_Always_ReturnsExpectedResult(string countryCode, string? expectedResult)
        {
            // Arrange
            var mockDeviceCountryIdentifier = new Mock<IDeviceCountryIdentifier>(MockBehavior.Strict);
            _ = mockDeviceCountryIdentifier.Setup(mock => mock.TryGetDeviceCountryCode()).Returns(countryCode);

            var gdprInfoService = new GdprInfoService(mockDeviceCountryIdentifier.Object);

            // Act
            var result = gdprInfoService.LongCountryCode;

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));

            mockDeviceCountryIdentifier.VerifyAll();
        }
    }

    public static class GdprInfoServiceTestsData
    {
        public static IEnumerable<TestCaseData> IsDeviceInEeaOrUnknowTestCases
        {
            get
            {
                yield return new TestCaseData("FI", true);
                yield return new TestCaseData("US", false);
                yield return new TestCaseData(null, true);
                yield return new TestCaseData("DE", true);
                yield return new TestCaseData("CA", false);
            }
        }
    }
}
