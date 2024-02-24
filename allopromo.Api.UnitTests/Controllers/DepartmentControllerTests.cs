using allopromo.Api.Controllers;
using allopromo.Core.Application.Dto;
using allopromo.Core.Services.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.UnitTests
{
    [TestFixture]
    public class DepartmentControllerTests
    {
        public DepartmentController SUT;
        public Mock<Core.Services.IDepartmentService> departmentServiceMock = new Mock<Core.Services.IDepartmentService>();
        public Mock<IBaseService<DepartmentDto>> _mockDepartmentService = new Mock<IBaseService<DepartmentDto>>();
        public Mock<IConfiguration> _mockConfig = new Mock<IConfiguration>();
        public DepartmentControllerTests()
        {
            SUT = new DepartmentController(
                departmentServiceMock.Object,
                _mockDepartmentService.Object,
                _mockConfig.Object);
        }

        [Test]
        public void PostDepartment_SHOULD_Return_CreatedDeparmentDto()
        {
            departmentServiceMock.Setup(x => x.CreateDepartmentAsync(It.IsAny<DepartmentDto>()))
                .Returns(System.Threading.Tasks.Task.FromResult(new DepartmentDto()));
            var result = SUT.CreateDepartment(
            new DepartmentDto
            {
                departmentName = "Les Frasques de Comforte"
            });
            Assert.IsNotNull(result);
            //Assert.AreEqual(typeof(OkObjectResult), result.GetType());
            Assert.AreEqual(typeof(System.Threading.Tasks.Task<IActionResult>), result.GetType());
        }
        [Test]
        public void GetDepartmentS_SHOULD_RETURN_Departments()
        {
            departmentServiceMock.Setup(x => x.GetDepartmentsAsync())
                .Returns(Task.FromResult(new List<Core.Entities.tDepartment>().AsEnumerable()));
            var result = SUT.GetDepartments();
            Assert.IsNotNull(result);
            //Assert.AreEqual(typeof(OkObjectResult), result.GetType());
            Assert.AreEqual(typeof(
                Task<ActionResult<IEnumerable<DepartmentDto>>>), result.GetType());
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
            var result = SUT.Put(new System.Guid().ToString(), dto);// new DepartmentDto departmentDto());
            Assert.IsNotNull(result);
        }
    }
}
