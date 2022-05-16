using allopromo.Core.Abstract;
using allopromo.Core.Application;
using allopromo.Core.Application.Dto;
using allopromo.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;
using NSubstitute.ReturnsExtensions;
using allopromo.Core.Services;
using System.Collections.Generic;
using System;

namespace alloPromo.Core.UnitTests.Domain.Application
{
    [TestClass]
    public class ProductServiceTests
    {
        private readonly IProductService _productServiceSUT;

        private readonly IProductQuery _productQuery = Substitute.For<IProductQuery>();

        public ProductServiceTests()
        {
            _productServiceSUT = new ProductService(_productQuery);
        }
        [TestMethod]
        public async Task ProductService_GetProductsByStore_SHOULD_Return_ProductsByStore()// shoud or not have args ?
        {
            //? only Data driven test methdos can have parameters - Did you intend to use D
            // Dynamic 365  - Did you intend to Use DataRow or DynamicData

            var listProducts = new List<ProductDto>();
            var store = new StoreDto();
            store.storeId = "keke";
            store.storeName = "FOUFOU Mangement";
            listProducts.Add(new ProductDto{
                    productId = 12,
                    productName = "sfsdfd", //90-72-2975--||// 99-90-67-71 ---6... mr simon
                    productStoreId = store
                }
            );
            listProducts.Add(new ProductDto
            {
                productId = 21,
                productName = "sfsdfd",
                productStoreId = store
            }
            );
            var expectedProducts = _productQuery.GetProductsByStoreIdAsync("keke");
            var actualProducts=await _productServiceSUT.GetProductsByStore(store.storeId);
            Assert.AreEqual(expectedProducts.Result, actualProducts);

            //var expected = await _productQuery.GetStoreByIdAsync(product);
            //if (expected == null)
                return;
            //var actual = await _productServiceSUT.GetStoreByIdAsync(product);//.Returns(
            

            //Assert.IsNotNull(actual);
            //Assert.IsTrue(actual.storeId.Equals(expected.storeId));//328721
        }
        //[TestMethod]
        public async Task StoreService_GetStoreAsyncSHOULD_ReturnNUll_IfNotFound()
        {
            StoreDto store = null;
            //var expected = await _storeQuery.GetStoreByIdAsync(null);
            //var actual = _storeServiceSUT.GetStoreByIdAsync("").Returns<Task>(x => null);
        }
        //[TestMethod]
        public void A()
        {

        }
        //[TestMethod]
        public void B()
        {

        }
    }
}
