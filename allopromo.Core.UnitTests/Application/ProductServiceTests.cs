using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
namespace alloPromo.Core.UnitTests.Application
{
    [TestFixture]
    public class ProductServiceTest
    {
        Mock<ModelStateDictionary> modelStateMock; 
        [TestCase]
        public void  ObtenirProduct_DEVRAIT_RetournerProduitParId()
        {

        }
        [TestCase]
        public void ObtenirProduct_DEVRAIT_RetournerProduitParIds()
        //public async Task ObtenirProduct_DEVRAIT_RetournerProduitParIds()
        {

        }
    }
}
