using System;
using System.Collections.Generic;
using System.Text;
using allopromo.Admin.Models.BusinessLogic;
using allopromo.Admin.Models.Dto;
using NuGet; //?
using NUnit;
using NUnit.Framework;
namespace allopromo.Admin.UnitTests.UnitTests.BL
{
    //1. TDD ? 
    //2. Mediator pattern with MVC  - other Pattern ? along with MVC ?

    [TestFixture]
    public class StoreManagerTests
    {
        [Test]
        public void StoreManager_SHOULDReturn_Null()
        {
            var storeManager = new StoreManager();
            var result = storeManager.ChangeStoreStatus(new StoreDto(), new StoreStatus());
            Assert.IsNotNull(result);        
        }
    }
}
