using allopromo.Core.Abstract;
using allopromo.Core.Services.Base;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.UnitTests.Application
{
    public class BaseServiceTests
    {
        private Mock<IRepository<TDpartment>> mockDepartment;
        public void  kj()
        {
            //var baseService = new BaseService<T>();
        }
    }
    public interface IRepositoryT<TEntity> where TEntity : class
    {

    }
    public class TDpartment
    {

    }
}
