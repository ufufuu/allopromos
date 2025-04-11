using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
//using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using allopromo.Core.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace allopromo.Core.Application.UnitTests
{
    [TestFixture]
    public class DeparmentServiceTests
    {
        public DepartmentService SUT;
        public Mock<IRepository<tDepartment>> repositoryMock = new Mock<IRepository<tDepartment>>();
        public DeparmentServiceTests()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                //cfg.AddProfile<AutoMapperProfile>();
            });
        }
        [SetUp]

        #region Init
        public void Init()
        {
            SUT = new DepartmentService(repositoryMock.Object);
        }
        #endregion

        /// <summary>
        /// Create Tests
        /// </summary>
        [Test]
        public void CreateDepartment_SHOULD_CreateAndReturn()
        {
            var departmentDto = new tDepartment { departmentName = "La Planque a Thierry" };
            var department = new DepartmentDto { departmentName = "La Plank" };
            var result = SUT.CreateDepartmentAsync(department);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.GetType(), typeof(Task));// tDepartment >); ; //);
        }
        /// <summary>
        /// Get Departement Tests
        /// </summary>


        #region Read
        [Test]
        public async Task GetDepartmentAsync_SHOULD_RETURN_Department_Async()
        {
            var departmentDto = new tDepartment
            {
                departmentId = new System.Guid().ToString(),
                departmentName = "adk",
                departmentThumbnail = "https://www.allopromo.com/images/department/0.jpg"
            };
            var department = SUT.GetDepartmentAsync(new System.Guid().ToString());
            Assert.IsNotNull(department);
        }
        [Test]
        public async Task GetDepartments_SHOULD_Return_DepartmentsAsync()
        {
            repositoryMock.Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult(new List<tDepartment>()));

            var result =await SUT.GetDepartmentsAsync();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.GetType(), typeof(List<tDepartment>));
        }
        #endregion

        /// <summary>
        /// Delete Department Tests
        /// </summary>
        /// 
        #region Delete
        public async Task Delete()
        {}
        #endregion
    }
}
