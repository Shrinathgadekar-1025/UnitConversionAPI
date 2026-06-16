using FluentAssertions;
using UnitConversionAPI.Models;
using UnitConversionAPI.Services;

namespace UnitConversionAPI.Tests.Services
{
    public class UnitConversionServiceTests
    {
        private readonly UnitConversionService _service = new();

        [Fact]
        public void Meter_To_Kilometer_Should_Return_1()
        {
            var request = new ConversionRequest
            {
                FromUnit = "meter",
                ToUnit = "kilometer",
                Value = 1000
            };

            var result = _service.Convert(request);
            result.Result.Should().Be(1);
        }

        [Fact]
        public void Kilometer_To_Meter_Should_Return_1000()
        {
            var request = new ConversionRequest
            {
                FromUnit = "kilometer",
                ToUnit = "meter",
                Value = 1
            };

            var result = _service.Convert(request);

            result.Result.Should().Be(1000);
        }

        [Fact]
        public void Celsius_To_Fahrenheit()
        {
            var request = new ConversionRequest
            {
                FromUnit = "celsius",
                ToUnit = "fahrenheit",
                Value = 100
            };

            var result = _service.Convert(request);

            result.Result.Should().Be(212);
        }

        [Fact]
        public void Pound_To_Kilogram()
        {
            var request = new ConversionRequest
            {
                FromUnit = "pound",
                ToUnit = "kilogram",
                Value = 1
            };

            var result = _service.Convert(request);

            result.Result.Should().BeApproximately(0.4536, 0.001);
        }

        [Fact]
        public void Invalid_Conversion_Should_Throw_Exception()
        {
            var request = new ConversionRequest
            {
                FromUnit = "meter",
                ToUnit = "kilogram",
                Value = 5
            };

            Assert.ThrowsAny<System.Exception>(() => _service.Convert(request));
        }
    }
}
