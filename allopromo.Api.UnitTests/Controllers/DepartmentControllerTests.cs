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
            SUT = new DepartmentController(_mockConfig.Object,
                _MockDepartmentService.Object);
        }
        [Test]
        public void PostDepartment_SHOULD_Return_CreatedDeparmentDto()
        {
            var result = SUT.PostDepartment(new DepartmentDto{departmentId = "89", 
                departmentName = "kl lklk"
            });
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
        }
        [Test]
        public void GetDepartmentS_SHOULD_RETURN_Deparments()
        {
            var result = SUT.GetDepartments();
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
        }
    }
}
