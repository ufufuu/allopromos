using allopromo.Core.Abstract;
using allopromo.Core.Entities;
using allopromo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Extensions;
using System;
namespace alloPromo.UnitTest.Infrastructure.Data
{
    //[TestClass]
    public class StoreRepositoryTests
    {
        private IStoreRepository _storeRepositorySUT = Substitute.For<IStoreRepository>();
        //private DbContextOptions options = Substitute.For<DbContextOptions>();

        private DbContextOptions<AppDbContext> options = Substitute.For<DbContextOptions<AppDbContext>>();


        //private AppDbContext _dbContext = Substitute.For<AppDbContext>();
        //public StoreRepositoryTests()
        //{
        //    _storeRepositorySUT = new StoreRepository(_dbContext);
        //}

        [TestMethod]
        public void Add_Magazin_DEVRAIT_CreerEtRetournerMagazin()
        {
            var t_store = new tStore();
            t_store.storeId = Guid.NewGuid().ToString();
            t_store.storeName = "Jojo Delices";
            //t_store.storeCreatedOn = DateTime.Now.ToUniversalTime();
            //t_store.storeBecomesInactiveOn = t_store.storeCreatedOn.AddMonths(6);

            var options = new DbContextOptions<AppDbContext>();

            var optionsBuilder= new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("DefaultDevConnection",
                x => x.MigrationsHistoryTable("__EFMigrationHistory", "allopromo"));

            var _dbContext = Substitute.For<AppDbContext>(optionsBuilder.Options);

           // _storeRepositorySUT = new allopromo.Infrastructure.Repositories.
             //   StoreRepository(_dbContext);

            _dbContext.ReturnsForAll<tStore>(t_store);


            //_dbContext.Stores.Add(t_store).ReturnsForAnyArgs<tStore>(t_store);
            //_dbContext.Stores.Add.Returns<tStore>null(;
            //dentityUserLogin<string> userLogin = new IdentityUserLogin<string>();
            tStore t_Store = _storeRepositorySUT.Add(t_store);
            Assert.IsNotNull(t_Store);
        }
        //[TestMethod]
        public void Obtenir_DEVRAIT_RetournerMagazin()
        {
        }
    }
}

// from the Method being Tested, what is being returned ? 
// Arrange argument being passed to the methode being tested - what isbeing done in the Mehod ?
// instance what is being returned from the method 
// expected !  REturns -> wha it sbeing returned 
// expected call, the method !  ----- Same argument being Passed  to Both !

//// Only interface & Virtual Methods Can be Mocked ?
