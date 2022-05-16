using allopromo.Core.Abstract;
using allopromo.Core.Entities;
using allopromo.Infrastructure.Abstract;
using allopromo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Infrastructure.UnitTests.Data
{
    [TestFixture]
    public class GenericRepositoryTests
    {
        //[TestCase]
        public void Creer_Type_DEVRAIT_RetournerTypeCree()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("allopromo")
                .Options;
            var store = new tStore { };
            Mock<InMemoryDatabase> db = new Mock<InMemoryDatabase>();
            using (var dbContext = new AppDbContext(options))
            {
                 dbContext.SaveChanges();
            }
            using (var dbContext = new AppDbContext(options))
            {
                IGenericRepository<tStore> _SUT = new GenericRepository<tStore>(dbContext);

            }
            //var _stu = new GenericRepository<tStore>(db.);

            var dbSetMock = new Mock<DbSet<tStore>>();
            dbSetMock.Setup(s => s.Add(new tStore()));

        }
        [Test]
        public void CREER_TYPE_DEVRAIT_ENREGISTRER()
        {

        }
        [Test]
        public void SAVE_TYPE_DEVRAIT_ENREGISTRER()
        {

        }
    }
}
