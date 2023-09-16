using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
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
        public Mock<IRepository<tDepartment>> RepositoryMock = new Mock<IRepository<tDepartment>>();
        public DeparmentServiceTests()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
        }
        [SetUp]
        public void Init()
        {
            SUT = new DepartmentService(RepositoryMock.Object);
        }
        [Test]
        public void CreateDepartment_SHOULD_CreateAndReturn()
        {
            var departmentDto = new DepartmentDto { departmentName = "La Planque a Thierry" };
            var result = SUT.CreateDepartmentAsync(departmentDto);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.GetType(), typeof(Task<DepartmentDto>));
        }
        [Test]
        public async Task GetDepartmentAsync_SHOULD_RETURN_Department_Async()
        {
            var departmentDto = new DepartmentDto
            {
                departmentId = new System.Guid().ToString(),
                departmentName = "adk",
                departmentThumbnail = "https://allo-promo.net/images/department/0.jpg"
            };
            var department = SUT.GetDepartmentAsync(new System.Guid().ToString());
            Assert.IsNotNull(department);
        }
        [Test]
        public async Task GetDepartments_SHOULD_Return_DepartmentsAsync()
        {
            var result =await SUT.GetDepartmentsAsync();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.GetType(), typeof(List<DepartmentDto>));
        }
    }
}
