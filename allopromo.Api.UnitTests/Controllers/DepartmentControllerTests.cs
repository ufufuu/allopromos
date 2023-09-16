using allopromo.Api.Controllers;
using allopromo.Core.Application.Dto;
using allopromo.Core.Services.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace allopromo.Api.UnitTests
{
    [TestFixture]
    public class DepartmentControllerTests
    {
        private Mock<IConfiguration> _mockConfig = new Mock<IConfiguration>();
        private DepartmentController SUT;
        private Mock<IBaseService<DepartmentDto>> _mockDepartmentService = new Mock<IBaseService<DepartmentDto>>();
        private Mock<Core.Services.IDepartmentService> _MockDepartmentService = new Mock<Core.Services.IDepartmentService>();
        public DepartmentControllerTests()
        {
            SUT = new DepartmentController(_mockConfig.Object, _MockDepartmentService.Object,
                _mockDepartmentService.Object);
        }
        [Test]
        public void PostDepartment_SHOULD_Return_CreatedDeparmentDto()
        {
            _MockDepartmentService.Setup(x => x.CreateDepartmentAsync(It.IsAny<DepartmentDto>()))
                .Returns(System.Threading.Tasks.Task.FromResult(new DepartmentDto()));
            var result = SUT.CreateDepartment(
            new DepartmentDto
            {
                departmentName = "Les Frasques de Comforte"
            });
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
        }
        [Test]
        public void GetDepartmentS_SHOULD_RETURN_Departments()
        {
            var result = SUT.GetDepartments();
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
        }
        [Test]
        public void GetDepartment_byName_SHOULD_RETURN_Department()
        {
            DepartmentDto departmentDto = new DepartmentDto
            {
                departmentName = "SuperMarkets",
                departmentId = System.Guid.NewGuid().ToString(),
            };
            var department = SUT.GetDepartmentByName(departmentDto.departmentName);
            Assert.IsNotNull(department);
        }
        [Test]
        public void Put_SHOULD_Mofify_Department()
        {
            var dto = new DepartmentDto();
            var result = SUT.Put(new System.Guid().ToString(), dto); // new DepartmentDto departmentDto());
            Assert.IsNotNull(result);
        }
    }
}
