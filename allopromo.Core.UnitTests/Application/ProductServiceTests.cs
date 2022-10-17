using allopromo.Core.Abstract;
using allopromo.Core.Services;
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
        Mock<IProductRepository> _productRepository = new Mock<IProductRepository>();
        [TestCase]
        public async Task ObtenirProduct_DEVRAIT_RetournerUneException()
        {
            var productService = new ProductService(_productRepository.Object);
            var result = await productService.GetProductById(null);
            //Assert.Throws<ArgumentNullException>(null);
            Assert.IsNull(result);
        }
        [TestCase]
        public void ObtenirProduct_DEVRAIT_RetournerProduitParId_Trouve()
        {
            var productService = new ProductService(_productRepository.Object);
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