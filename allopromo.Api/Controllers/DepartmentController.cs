using allopromo.Model.Validation;
using allopromo.Infrastructure.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.AspNetCore.Authorization;
using allopromo.Core.Contracts;
using allopromo.Core.Abstract;
using allopromo.Core.Exceptions;
using allopromo.Core.Application.Dto;
using System.Linq;
using System.Threading.Tasks;
using allopromo.Core.Services.Base;
using allopromo.Core.Services;
using allopromo.Core.Entities;
namespace allopromo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _config;
        private IBaseService<DepartmentDto> _departmentService; //= new DepartmentService<DepartmentDto>();

        private IBaseService<DepartmentDto> _departmentServices;
        private readonly IExceptionWriter _exceptionWriter;
        
        public DepartmentController(IConfiguration config,
               IBaseService<DepartmentDto> departmentServices,
        IBaseService<DepartmentDto> departmentService)
        {
            _departmentService = departmentService;
            _config = config;
            //_exceptionWriter = exceptionWriter;
            _departmentServices = departmentServices;
        }
        [HttpPost]
        public IActionResult PostDepartment ([FromBody] DepartmentDto departmentDto)
        {
            try
            {
                _departmentService.Create(departmentDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(departmentDto);
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _departmentServices.GetEntities();
            return Ok(departments);
        }
        [HttpGet]
        [Route("{departmentId}")]
        public IActionResult GetDepartmentById(string cityId)
        {
            try 
            {
                String city= string.Empty;
                return Ok(city);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        [Route("delete/{departmentId}")]
        public async Task<IActionResult> Delete(string Id)
        {
            try
            {
                var department = from c in await _departmentService.GetEntities()  //(Id)
                           where c.departmentName.Equals(Id)
                           select c;
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
