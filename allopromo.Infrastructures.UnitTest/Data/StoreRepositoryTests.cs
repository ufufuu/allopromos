using allopromo.Infrastructure.Data;
using Moq;
using NUnit.Framework;
using System;
using allopromo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using allopromo.Core.Entities;
namespace allopromo.Infrastructures.UnitTest.Data
{
    [TestFixture]
    public class StoreRepositoryTests
    {
        //[TestCase]
        public void Creer_Strore_DEVRAIT_RetournerStoreCree()
        {
            var store = new tStore { };
            Mock<DbContextOptions<AppDbContext>> options = new Mock<DbContextOptions<AppDbContext>>();
            Mock<InMemoryDatabase> db = new Mock<InMemoryDatabase>();

            var dbContextMock = new Mock<AppDbContext>(options.Object);// options.Object);
            var dbSetMock = new Mock<DbSet<tStore>>();

            dbSetMock.Setup(s => s.Add(new tStore()));
            dbContextMock.Setup(s => s.Set<tStore>()).Returns(dbSetMock.Object);

            //var storeRepository = new StoreRepository();
            var storeRepository = new StoreRepository(dbContextMock.Object);
            var storeCree = storeRepository.Add(store);
            Assert.IsNotNull(storeCree);
        }
        [TestCase]
        public void Obtenir_DEVRAIT_Retourner_StoreSiExiste()
        {
            var dbContextMock = new Mock<AppDbContext>();
            var dbSetMock = new Mock<DbSet<tStore>>();
            dbSetMock.Setup(x => x.Find(new tStore()));
            var storeRepository = new StoreRepository(dbContextMock.Object);
            var storeTrouve = storeRepository.GetStoreByIdAsync(Guid.NewGuid().ToString());
            Assert.IsNotNull(storeTrouve);
        }
        [TestCase]
        public void Obtenir_DEVRAiT_RetournerNullSiPasTrouveOuNullEnArgument()
        {
            var dbContextMock = new Mock<AppDbContext>();

            //var dbSetMock = new Mock<DbSet<tStore>>();
            //dbSetMock.Setup(x => x.Find(new tStore()));

            dbContextMock.Setup(s => s.Find(null)).Returns((DbSet<tStore>)null);

            var _SUT = new StoreRepository(dbContextMock.Object);
            var storeTrouve = _SUT.GetStoreByIdAsync(null).Result;                                  
            int y = 7;
            Assert.IsNull(storeTrouve);
        }
        //[TestCase]
        public void Obtenir_DEVRAIT_RetournerNulSiPasTrouve()
        {
            //Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal
        }
    }
}

//4-2545879
//daniel pronovo ---
//https://docs.microsoft.com/fr-fr/ef/core/testing/testing-without-the-database

// In-memory i

//virtual mthod ? + 

//out vs ref >
//ref  is intiliazed b4 entering thr funct whil out is not
// out to return multiple values 

//lazy loading vs eager loading 
//eager : include queries ----preferably, less costly ---- loading Related Entitues ? eager: desireux : lad related data along with main 
//proxy class ?>
