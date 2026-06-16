using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UnitConversionAPI.Controllers;
using UnitConversionAPI.Models;
using UnitConversionAPI.Services;

namespace UnitConversionAPI.Tests.Controllers
{
    public class UnitConversionControllerTests
    {
        [Fact]
        public void Convert_Should_Return_Ok()
        {
            var response = new ConversionResponse
            {
                FromUnit = "meter",
                ToUnit = "kilometer",
                InputValue = 1000,
                Result = 1,
                Category = "Length"
            };

            var service = new Mock<IUnitConversionService>();

            service.Setup(s => s.Convert(It.IsAny<ConversionRequest>())).Returns(response);

            var controller = new UnitConversionController(service.Object);

            var result = controller.Convert(new ConversionRequest());

            result.Should().BeOfType<OkObjectResult>();
        }
    }
}