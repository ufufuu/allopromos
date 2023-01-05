using allopromo.Core.Abstract;
using allopromo.Core.Services.Base;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.UnitTests.Application
{
    [TestFixture]
    public class BaseServiceTests
    {
        private Mock<IRepository<TDepartment>> _mockDepartment = new Mock<IRepository<TDepartment>>();
        [Test]
        public void Create_Should_Add_Entity()
        {
            //IBaseService<TDepartment> baseService = new BaseService<TDepartment>(_mockDepartment.Object);
            //_mockDepartment.Setup(x => x.Add(It.IsAny<TDepartment>()));
            //baseService.Create(It.IsAny<TDepartment>());
            //_mockDepartment.Verify(x => x.Add(It.IsAny<TDepartment>()), Times.Once);
        }
    }
    public interface IRepositoryT<TEntity> where TEntity : class
    {
    }
    public class TDepartment
    {
    }
}
