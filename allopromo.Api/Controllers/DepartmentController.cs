using allopromo.Model.Validation;
using allopromo.Infrastructure.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.AspNetCore.Authorization;
//using allopromo.Core.Contracts;
using allopromo.Core.Abstract;
using allopromo.Core.Exceptions;
using allopromo.Core.Application.Dto;
using System.Linq;
using System.Threading.Tasks;
using allopromo.Core.Services.Base;
using allopromo.Core.Services;
using allopromo.Core.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace allopromo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    //[Produces("application/json")]

    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _appDb;
        private IBaseService<DepartmentDto> _departmentService;
        
        private readonly IDepartmentService _DepartmentService;

        //private readonly ILogger<DepartmentController> _logger;
        //private readonly IExceptionWriter _exceptionWriter;

        public DepartmentController(IConfiguration config,
            IDepartmentService DepartmentService ,
            IBaseService<DepartmentDto> departmentService)
        {
            _DepartmentService = DepartmentService;
            _departmentService = departmentService;
            _config = config;
            //_exceptionWriter = exceptionWriter;
        }
        #region Create
        [HttpPost]
        
        //[Authorize]
        //[Core.Helpers.JwtBasicAuthorize]n,n,
        [Route("")]
        public IActionResult CreateDepartment([FromBody] DepartmentDto departmentDto)
        {
            try
            {
                //var httpContextAccessor = new HttpContextAccessor();
                //var currentUser = httpContextAccessor.HttpContext.User.Identity;
                //if (currentUser == null)
                //{
                //    return Unauthorized();
                //}
                //else
                //{
                    if (departmentDto != null)
                    {
                       var fr= _DepartmentService.CreateDepartmentAsync(departmentDto);
                        if (fr != null)
                        {
                            return Ok(departmentDto);
                        }
                        return NoContent();
                    }
                    else
                    {
                        return NoContent();
                    }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Read
        [HttpGet]
        [Route("")]
        public IActionResult GetDepartments()
        {
            var departments = _DepartmentService.GetDepartmentsAsync();
            if(departments!=null)
                return Ok(departments);
            return NotFound();
        }
        [HttpGet]
        [Route("{departmentName}")]
        public IActionResult GetDepartmentByName(string departmentName)
        {
            if (departmentName != null)
            {
                var department = _DepartmentService.GetDepartmentAsync(departmentName);
                return Ok(department);
            }
            else
                return NotFound();
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
        #endregion

        #region Update
        [HttpPut]
        [Route("departmentId")]
        public async Task<IActionResult> Put(string departmentId, 
            [FromBody] DepartmentDto departmentDto)
      {
            try
            {
                if (departmentId != null)
                {
                    var department = await _DepartmentService.GetDepartmentAsync(
                        departmentDto.departmentId);
                    await _DepartmentService.UpdateDepartmentAsync(departmentId, departmentDto);
                return Ok(department);
                }
                else
                    return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region Delete
        [HttpDelete]
        [Route("department+{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            try
            {
                var department = from c in await _departmentService.GetEntities()
                                 select c;
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
