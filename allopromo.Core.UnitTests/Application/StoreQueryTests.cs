//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Threading.Tasks;
//using allopromo.Infrastructure.Repositories;

using allopromo.Core.Application;
using Moq;
namespace alloPromo.Core.UnitTests.Application
{
    [TestFixture]
    public class StoreQueryTests
    {
        private Mock<allopromo.Core.Abstract.IStoreRepository> _storeRepository;
        //[Setup]
        public void Setup()
        {

        }
        [TestCase]
        public async Task ObtenirProduct_DEVRAIT_RetournerProduitParId()
        {
            //var SUT = new StoreQuery(_storeRepository.Object);
        }
    }
}

// Repo ?
//Query Pattern ?
// Is N-Tiers a sort of  Client-Server Architecture ?