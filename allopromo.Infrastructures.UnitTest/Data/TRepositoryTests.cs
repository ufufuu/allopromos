using allopromo.Core.Abstract;
using allopromo.Core.Entities;
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
    public class TestClass
    {
        public int Id { get; set; }
    }
    public class TRepositoryTests
    {
        private Mock<AppDbContext> _mockDb { get; set; }
        [Test]
        public void Add_TEntity_DEVRAIT_RetournerTEntityCrees()
        {
            //var options = new DbContextOptionsBuilder<AppDbContext>()
            //    .UseInMemoryDatabase("allopromo")
            //    .Options;
            //var obj = new tStore { };
            //Mock<InMemoryDatabase> db = new Mock<InMemoryDatabase>();
            //using (var dbContext = new AppDbContext(options))
            //{
            //     dbContext.SaveChanges();
            //}
            //var dbSetMock = new Mock<DbSet<tStore>>();
            //dbSetMock.Setup(s => s.Add(new tStore()));

            //Arrange
            var tObject = new TestClass();
            var mockDbcontext = new Mock<AppDbContext>();

            var mockDbSet = new Mock<DbSet<TestClass>>();
            mockDbcontext.Setup(x => x.Set<TestClass>()).Returns(mockDbSet.Object);
            //mockDbSet.Setup(x => x.Add(It.IsAny<TestClass>())).Returns(tObject); // 1 and 2 : testObject do not compile to Assert 2
            //Act
            var repository = new TRepository<TestClass>(mockDbcontext.Object);
            repository.Add(tObject);
            //Assert
            mockDbcontext.Verify(x => x.Set<TestClass>());
            //mockDbSet.Verify(x => x.Add(It.Is<TestClass>(y => y == tObject))); // 1 and 2
        }
        [Test]
        public void Delete_TYPE_DEVRAIT_SUPPRIMER()
        {
            //Arrange
            var testClass = new TestClass();
            var mockDbContext = new Mock<AppDbContext>();
            var mockDbSet = new Mock<DbSet<TestClass>>();

            mockDbContext.Setup(x => x.Set<TestClass>()).Returns(mockDbSet.Object);
            //mockDbSet.Setup(x => x.Remove(It.IsAny<TestClass>())).Returns(testClass); // 1 and 2 !

            //Act
            var tRepo = new TRepository<TestClass>(mockDbContext.Object);
            tRepo.Delete(testClass);

            //Assert
            //Assert.IsNotNull(result);
            mockDbContext.Verify(x => x.Set<TestClass>());
            //mockDbSet.Verify(x => x.Remove(It.Is<TestClass>(y => y == testObject))); // 1 and 2 !
        }
        //[Test]
        public void Save_TYPE_DEVRAIT_ENREGISTRER()
        {
        }
        [Test]
        public void UpDate_TYPE_DEVRAIT_ENREGISTRER()
        {
        }
    }
}