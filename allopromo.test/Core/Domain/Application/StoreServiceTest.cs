using allopromo.Core.Abstract;
using allopromo.Core.Application;
using allopromo.Core.Application.Dto;
using allopromo.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;
using NSubstitute.ReturnsExtensions;
namespace alloPromo.Core.UnitTests.Domain.Application
{
    [TestClass]
    public class StoreServiceTest
    {
        private readonly IStoreService _storeServiceSUT;

        private readonly IStoreQuery _storeQuery = Substitute.For<IStoreQuery>();

        public StoreServiceTest()
        {
            _storeServiceSUT = new StoreService(_storeQuery);
        }
        [TestMethod]
        public async Task GetStore_SHOULD_Return_StoreById()
        {
            var store = new StoreDto();
            store.storeId = "lklk";
            store.storeName = "SED Food";
            var expected = await _storeQuery.GetStoreByIdAsync(store.storeId);
            if (expected == null)
                return;
            var actual = await _storeServiceSUT.GetStoreByIdAsync(store.storeId);//.Returns(
            
            /*if (actual == null)
                return;
            int y = 5;*/

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.storeId.Equals(expected.storeId));//328721
        }
        [TestMethod]
        public async Task StoreService_GetStoreAsyncSHOULD_ReturnNUll_IfNotFound()
        {
            StoreDto store = null;
            var expected = await _storeQuery.GetStoreByIdAsync(null);
            var actual = _storeServiceSUT.GetStoreByIdAsync("").Returns<Task>(x => null);
        }
        [TestMethod]
        public void ObtenirStoresAsync_DEVRAIT_Retouner_AllProduitsParStore()
        {

        }
        [TestMethod]
        public void ObtenirStoresAsync_DEVRAIT_Retouner_AllMagazinsParCategory()
        {

        }
    }
}
