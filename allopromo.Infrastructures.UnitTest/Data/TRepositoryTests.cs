using allopromo.Core.Abstract;
using allopromo.Core.Entities;
using allopromo.Infrastructure.Abstract;
using allopromo.Infrastructure.Data;
using allopromo.Infrastructure.Repositories;
using allopromo.Shared.Abstract;
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
    public class TRepositoryTests
    {
        private Mock<AppDbContext> _mockDb { get; set; }
        [Test]
        public void Add_TEntity_DEVRAIT_RetournerTEntityCrees()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("allopromo")
                .Options;
            var obj = new tStore { };
            Mock<InMemoryDatabase> db = new Mock<InMemoryDatabase>();
            using (var dbContext = new AppDbContext(options))
            {
                 dbContext.SaveChanges();
            }
            var dbSetMock = new Mock<DbSet<tStore>>();
            dbSetMock.Setup(s => s.Add(new tStore()));
        }
        [Test]
        public void UpDate_TYPE_DEVRAIT_ENREGISTRER()
        {
        }
        [Test]
        public void Delete_TYPE_DEVRAIT_SUPPRIMER(object obj)
        {
            var tRepo = new TRepository<Object>(_mockDb.Object);
            Object result = tRepo.Delete(obj);
            Assert.IsNotNull(result);
        }
        //[Test]
        public void Save_TYPE_DEVRAIT_ENREGISTRER()
        {
        }
    }
}
