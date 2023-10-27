using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Ticketing.Api.Controllers;

namespace Ticketing.Api.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Should_Return_Forecast_Results()
        {
            //arrange
            
            var loggerMock =new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);

            //act

            var result = controller.Get();

            //assert

            Assert.NotNull(result);
            Assert.True(result.Count() > 1);

                //use shouldly
                result.ShouldNotBeNull();
                result.Count().ShouldBeGreaterThan(1);

        }
    }
}