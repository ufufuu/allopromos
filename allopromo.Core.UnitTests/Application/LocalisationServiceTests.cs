using allopromo.Core.Abstract;
using allopromo.Core.Contracts;
using allopromo.Core.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.UnitTests.Application
{
    public class LocalisationServiceTests
    {
        private Mock<Abstract.IRepository<tCity>> citiesRepoMock;

        //[Test]
        //public void GetUserCurrentCity_SHOULD_GetCityAsync()
        //{
        //    citiesRepoMock = new Mock<IRepository<tCity>>();
        //    citiesRepoMock.Setup(x => x.GetAllAsync())

        //        .Returns(Task.FromResult(new List<tCity>().AsQueryable()));

        //    var localiseService = new LocalisationService(citiesRepoMock.Object);
        //    var obj = citiesRepoMock.Object;
        //    citiesRepoMock.Verify(x => x.GetAllAsync(), Times.AtMostOnce());
        //}
        public void GetCities_SHOULD_ReturnCities()
        {
        }
        public void GetCity_SHOULD_City()
        {
        }
        public void PUT_SHOULD_Create_City()
        {
        }
    }

}
