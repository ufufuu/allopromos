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
        private IBaseService<DepartmentDto> _departmentService;
        private readonly IExceptionWriter _exceptionWriter;
        public DepartmentController(IConfiguration config,
            IBaseService<DepartmentDto> departmentService
                                        )
        {
            _departmentService = departmentService;
            _config = config;
         //_exceptionWriter = exceptionWriter;
        }

        [HttpPost]
        public IActionResult PostDepartment ([FromBody] DepartmentDto departmentDto)
        {
            String Id = String.Empty;
            try
            {
                var department = new tDepartment();
                department.departmentId = departmentDto.departmentId.ToString();
                department.departmentName = departmentDto.departmentName.ToString();
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

            return BadRequest();
        }
        [HttpGet]
        [Route("cities+{cityId}")]
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
        [Route("department+{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            try
            {
                var department = from c in await _departmentService.GetEntities()  //(Id)
                           where c.departmentId.Equals(Id)
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
