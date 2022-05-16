using allopromo.Infrastructure.Data;
using Moq;
using NUnit.Framework;
using System;
using allopromo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using allopromo.Core.Entities;
using allopromo.Core.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Infrastructures.UnitTest.Data
{
    [TestFixture]
    public class StoreRepositoryTests
    {
       [TestCase]
        public void Creer_Store_DEVRAIT_RetournerStoreCree()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("allopromo")
                .Options;
            var store = new tStore { };
            Mock<InMemoryDatabase> db = new Mock<InMemoryDatabase>();
            using (var dbContext = new AppDbContext(options))
            {
                dbContext.Stores.Add(
                    new tStore
                    {
                        storeId = Guid.NewGuid().ToString()
                    }
                    );
                dbContext.Stores.Add(
                    new tStore { storeId = Guid.NewGuid().ToString() 
                    }
                    );
                dbContext.Stores.Add(
                    new tStore
                    {
                        storeId = Guid.NewGuid().ToString()
                    }
                    );
                dbContext.SaveChanges();
            }
            List<tStore> storesS = new List<tStore>();
            using (var dbContext = new AppDbContext(options))
            {
                IStoreRepository sut = new StoreRepository(dbContext);
                storesS = sut.GetStoresAsync().ToList();
            }
            IStoreRepository _SUT = new StoreRepository(new AppDbContext(options));
            var stores =  _SUT.GetStoresAsync();

            //var dbContextMock = new Mock<AppDbContext>(options.Object);// options.Object);

            var dbSetMock = new Mock<DbSet<tStore>>();
            dbSetMock.Setup(s => s.Add(new tStore()));

            //dbContextMock.Setup(s => s.Set<tStore>()).Returns(dbSetMock.Object);
            //IStoreRepository storeRepository = new StoreRepository(dbContextMock.Object);

            var storeCree =  _SUT.Add(store);

            //Assert.IsNotNull(storeCree);
            Assert.IsNotNull(stores);
            Assert.AreEqual(3, storesS.Count);
        }
        [TestCase]
        public void Obtenir_DEVRAIT_RetournerStoresPer_Page()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("allopromo")
                .Options;
            List<tStore> stores = new List<tStore>();
            using(var dbContext= new AppDbContext(options))
            {
                dbContext.Stores.Add(new tStore { storeId = Guid.NewGuid().ToString(), });
                dbContext.Stores.Add(new tStore { storeId = Guid.NewGuid().ToString(),  });
                dbContext.Stores.Add(new tStore { storeId = Guid.NewGuid().ToString(),  });
                dbContext.SaveChanges();
            }
            IEnumerable<tStore> storesPerPage = null;
            using (var dbContext = new AppDbContext(options))
            {
                var sut = new StoreRepository(dbContext);
                storesPerPage = sut.GetStoresByCategoryIdAsync(9).Result.ToList();//, 2);
            }
            Assert.AreEqual(storesPerPage.ToList().Count, 3);
        }
        [TestCase]
        public void Obtenir_DEVRAIT_RetournerStores_Per_Page_With_Limit_And_OffSet()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("allopromo")
                .Options;
            List<tStore> stores = new List<tStore>();
            using (var dbContext = new AppDbContext(options))
            {
                dbContext.Stores.Add(new tStore { storeId = Guid.NewGuid().ToString(),  });
                dbContext.Stores.Add(new tStore { storeId = Guid.NewGuid().ToString(),  });
                dbContext.Stores.Add(new tStore { storeId = Guid.NewGuid().ToString(),  });

                dbContext.Stores.Add(new tStore { storeId = Guid.NewGuid().ToString(),  });
                dbContext.Stores.Add(new tStore { storeId = Guid.NewGuid().ToString(),  });
                dbContext.Stores.Add(new tStore { storeId = Guid.NewGuid().ToString(),  });

                dbContext.Stores.Add(new tStore { storeId = Guid.NewGuid().ToString(),  });
                dbContext.Stores.Add(new tStore { storeId = Guid.NewGuid().ToString(),  });
                dbContext.Stores.Add(new tStore { storeId = Guid.NewGuid().ToString(),  });
                //storesPerPage = sut.GetStoresByCategoryIdAsync(category.storeCategoryId, 3, 3).Result.ToList();
                dbContext.SaveChanges();
            }
            IEnumerable<tStore> storesPerPage = null;
            using (var dbContext = new AppDbContext(options))
            {
                var sut = new StoreRepository(dbContext);
                storesPerPage = sut.GetStoresByCategoryIdAsync(8,2,3).Result.ToList();
            }
            Assert.AreEqual(storesPerPage.ToList().Count, 3);
        }
        //[TestCase]
        public void Obtenir_DEVRAIT_Retourner_StoreSiExiste()
        {
            var dbContextMock = new Mock<AppDbContext>();
            var dbSetMock = new Mock<DbSet<tStore>>();
            dbSetMock.Setup(x => x.Find(new tStore()));
            IStoreRepository storeRepository = new StoreRepository(dbContextMock.Object);
            var storeTrouve = storeRepository.GetStoresByCategoryIdAsync(1, 5, 1);
            Assert.IsNotNull(storeTrouve);
        }
        //[TestCase]
        public void Obtenir_DEVRAiT_RetournerNullSiPasTrouveOuNullEnArgument()
        {
            var dbContextMock = new Mock<AppDbContext>();
            dbContextMock.Setup(s => s.Find(null)).Returns((DbSet<tStore>)null);
            IStoreRepository _SUT = new StoreRepository(dbContextMock.Object);
            var storeTrouve = _SUT.GetStoresByCategoryIdAsync(1, 5, 1).Result;
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

//https://docs.microsoft.com/fr-fr/ef/core/testing/testing-without-the-database

// In-memory i //virtual mthod ? +  //out vs ref > //ref  is intiliazed b4 entering thr funct whil out is not 
// out to return multiple values //lazy loading vs eager loading 
//eager : include queries ----preferably, less costly ---- loading Related Entitues ? eager: desireux : lad related data along with main 
//proxy class ?> n//4-2545879 //daniel pronovo ---
