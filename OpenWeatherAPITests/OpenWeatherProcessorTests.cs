
using Moq;
using OpenWeatherAPI;
using System;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.ViewModels;
using Xunit;

namespace OpenWeatherAPITests
{
    public class OpenWeatherProcessorTests : IDisposable
    {

        public void Dispose()
        {
            
        }

       

        [Fact]
        public void GetOneCallAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {

            var test = OpenWeatherProcessor.Instance;

            test.ApiKey = null;
            
            Task<OpenWeatherOneCallModel> Ow = test.GetOneCallAsync();

            Assert.Throws<AggregateException>(() => Ow.Result);
        }

        [Fact]
        public void GetCurrentWeatherAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {
            var test = OpenWeatherProcessor.Instance;

            test.ApiKey = null;

            Task<OWCurrentWeaterModel> Ow = test.GetCurrentWeatherAsync();

            Assert.Throws<AggregateException>(() => Ow.Result);
        }

        [Fact]
        public void GetOneCallAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {
            var test = OpenWeatherProcessor.Instance;

            ApiHelper.ApiClient = null;
            test.ApiKey = "ApiKey";

            Task<OpenWeatherOneCallModel> Ow = test.GetOneCallAsync();

            Assert.Throws<AggregateException>(() => Ow.Result);
        }

        [Fact]
        public void GetCurrentWeatherAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {
            //Arrange

            var Temp = OpenWeatherProcessor.Instance;
            // Act    
            ApiHelper.ApiClient = null;
            Temp.ApiKey = "ApiKey";
            // Assert
            Task<OWCurrentWeaterModel> Ow = Temp.GetCurrentWeatherAsync();

            Assert.Throws<AggregateException>(() => Ow.Result);
        }
    }
}
