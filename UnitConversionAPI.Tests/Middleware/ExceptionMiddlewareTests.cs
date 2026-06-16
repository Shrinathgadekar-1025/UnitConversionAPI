using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using UnitConversionAPI.Middleware;

namespace UnitConversionAPI.Tests.Middleware
{
    public class ExceptionMiddlewareTests
    {
        [Fact]
        public async Task Middleware_Should_Handle_Exception()
        {
            RequestDelegate next = (ctx) =>
            {
                throw new System.Exception("Test");
            };

            var logger = new Mock<ILogger<ExceptionMiddleware>>();

            var middleware = new ExceptionMiddleware(next, logger.Object);

            var context = new DefaultHttpContext();

            await middleware.InvokeAsync(context);

            Assert.Equal(500, context.Response.StatusCode);
        }
    }
}
