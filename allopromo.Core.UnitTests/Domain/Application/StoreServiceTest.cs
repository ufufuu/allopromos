using allopromo.Core.Abstract;
using allopromo.Core.Application;
using allopromo.Core.Application.Dto;
using allopromo.Core.Model;
using Moq;
//using NSubstitute;
using NUnit.Framework;
namespace alloPromo.Core.UnitTests.Domain.Application
{
    [TestFixture]
    public class StoreServiceTest
    {
        private readonly IStoreService _sut;

        private readonly Mock<IStoreQuery> _storeQuery = new Mock<IStoreQuery>();
        public StoreServiceTest()
        {
           // _sut = new StoreService(_storeQuery.Object);
        }
        [TestCase]
        public void CreateStore_SHOULD_CreateAndReturnStoreDto()
        {


            StoreDto storeDto = new StoreDto { };

            //var sut = new StoreService(_storeQuery.Object);

            //var store = sut.CreateStore(storeDto);

        }
        //[TestCase]
        public void GetStore_SHOULD_Return_StoreById()
        {
            var store = new allopromo.Core.Application.Dto.StoreDto();
            store.storeId = "lklk";
            store.storeName = "SED Food";
            var result = _sut.GetStoreByIdAsync(store.storeId);
            Assert.IsNotNull(result);
            Assert.IsTrue(store.storeId.Equals(result.Id));
        }
        //[TestCase]
        public void ObtenirStoresAsync_DEVRAIT_Retouner_AllMagazins()
        {
        }
    }
}
