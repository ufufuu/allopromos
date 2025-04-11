using allopromo.Core.Abstract;
using allopromo.Core.Entities;
using allopromo.Core.Services;
//using allopromo.Shared.Abstract;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Http.ModelBinding;
namespace alloPromo.Core.UnitTests.Application
{
    [TestFixture]
    public class ProductServiceTest
    {
        Mock<IStoreService> _storeService = new Mock<IStoreService>();
        Mock<IRepository<tProduct>> _productRepository = new Mock<IRepository<tProduct>>();
        Mock<IRepository<tProductCategory>> _productCategoryRepository = new Mock<IRepository<tProductCategory>>();
        ProductService _SUT { get; set; }
        public ProductServiceTest()
        {
            _SUT = new ProductService(_productRepository.Object, _productCategoryRepository.Object,
                _storeService.Object);
        }
        [Test]
        public void CreateProducts_SHOULD_Return_CreatedProduct()
        {
            var productObj = new tProduct(){ };
            var result = _SUT.CreateProductAsync(productObj, "");
            Assert.IsNotNull(result);
        }
        [TestCase]
        public async Task ObtenirProduct_DEVRAIT_RetournerUneException()
        {
            var result = await _SUT.GetProductById(null);
            //Assert.Throws<ArgumentNullException>(null);
            Assert.IsNull(result);
        }
        [TestCase]
        public void ObtenirProduct_DEVRAIT_RetournerProduitParId_Trouve()
        {
            var productService = _SUT;
            var result = productService.GetProductById(It.IsAny<string>());
            Assert.IsNotNull(result);
        }
        [TestCase]
        public void ObtenirProduct_DEVRAIT_RetournerProduitParIds()
        {
        }
    }
}
//Mock<ModelStateDictionary> modelStateMock;