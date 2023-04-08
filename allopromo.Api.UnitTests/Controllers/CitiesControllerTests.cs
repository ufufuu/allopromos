//using Microsoft.VisualStudio.TestTools.UnitTesting;
using allopromo.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using allopromo.Core.Abstract;
using Microsoft.Extensions.Configuration;
using allopromo.Api.Controllers;
using System.Threading.Tasks;
using allopromo.Core.Application.Dto;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace allopromo.Api.UnitTests
{
    [TestFixture()]
    public class CitiesControllerTests
    {
        private Mock<ILocalisationService>  _localizeServiceMock = new Mock<ILocalisationService>();
        private Mock<IConfiguration> _configMock = new Mock<IConfiguration>();
        private CitiesController _sut { get; set; }
        public CitiesControllerTests()
        {
            _sut = new CitiesController(_configMock.Object, _localizeServiceMock.Object);
        }
        [Test]
        public void CitiesController_GetCurrentCity_RETURN_Cities()
        {
            _localizeServiceMock.Setup(x => x.GetCities()).Returns(Task.FromResult(GetCities()));
            var cities = _sut.GetCities();
            Assert.AreEqual(cities.GetType(),typeof(Task<IActionResult>));
            Assert.IsNotNull(cities);
        }
        [Test]
        public void CitiesController_GetCurrentCity_RETURN_City()
        {
            //Arrange
            var ip = "";
            _localizeServiceMock.Setup(x => x.GetUserCurrentCity(It.IsAny<string>()))
                .Returns(Task.FromResult(ip));
            var localiseServiceMock = new Mock<ILocalisationService>();
            localiseServiceMock.Setup(x => x.GetUserCurrentCity(It.IsAny<string>()))
                .Returns(Task.FromResult(ip));
            var fkfk = localiseServiceMock.Object;
            var rt = fkfk.GetUserCurrentCity(ip);

            //var result = citiesController.getCurrentCity(ip);
            //Act
            //Assert
            //Assert.IsNotNull(result);
            //Assert.AreEqual(res, typeof(string));

            localiseServiceMock.Verify(x => x.GetUserCurrentCity(ip), Times.AtMostOnce());
        }
        private IEnumerable<Core.Application.Dto.CityDto> GetCities()
        {
            var cities = new List<Core.Application.Dto.CityDto>();
            cities.Add(new CityDto { cityName = "" });
            cities.Add(new CityDto {  cityName = "" });
            return cities.AsEnumerable();
        }
        [TestCase()]
        public void PostCreatesCityTest()
        {
        }
        [TestCase()]
        public void PostCreatesCityTest1()
        {
        }
    }
}