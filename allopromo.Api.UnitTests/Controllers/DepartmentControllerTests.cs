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
        private Mock<IBaseService<DepartmentDto>> _mockDepartmentService = new Mock<IBaseService<DepartmentDto>>();
        [Test]
        public void PostDepartment_SHOULD_Return_CreatedDeparmentDto()
        {
            //var departmentController = new DepartmentController(_mockConfig.Object, 

            //    _mockDepartmentService.Object);
            //var result = departmentController.PostDepartment(new DepartmentDto 
            //{departmentName="Boulangeries & Patisseries" 
            //});
            //Assert.IsNotNull(result);
            //Assert.AreEqual(typeof(OkObjectResult), result.GetType());
        }
    }
}
