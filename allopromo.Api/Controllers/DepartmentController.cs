using allopromo.Model.Validation;
using allopromo.Infrastructure.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.AspNetCore.Authorization;
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
using System.Collections.Generic;

namespace allopromo.Api.Controllers
{
    [Route("api/v1/[controller]")]

    //[Produces("application/json")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public readonly IConfiguration _config;
        public readonly AppDbContext _appDb;
        public readonly IDepartmentService _DepartmentService;
        public IBaseService<DepartmentDto> _departmentService;
        public readonly IRepository<tDepartment> _deparmentRepository;

        private readonly AutoMapper.IMapper _mapper;
        //private readonly ILogger<DepartmentController> _logger;
        //private readonly IExceptionWriter _exceptionWriter;

    #region Constructors
        public DepartmentController(
            IDepartmentService DepartmentService,
            IBaseService<DepartmentDto> departmentService,
            IConfiguration config)
        {
            _DepartmentService = DepartmentService;
            _departmentService = departmentService;
            _config = config;

        }
        #endregion
    #region Create
        [HttpPost]

        //[Authorize]
        //[Core.Helpers.JwtBasicAuthorize]n,n,

        [Route("")]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentDto departmentDto)
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
                    //Task department = 
                        await _DepartmentService.CreateDepartmentAsync(departmentDto);

                       // if (department != null)
                        //{
                            return Ok(departmentDto);
                        //}
                        //return NoContent();
                    }
                    else
                    {
                        return BadRequest();
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
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetDepartments()
        {
            var departments = await _DepartmentService.GetDepartmentsAsync();
            if(departments!=null)
                return Ok(departments);
            return NotFound();
        }
        [HttpGet]
        [Route("{departmentName}")]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetDepartmentByName(string departmentName)
        {
            if (departmentName != null)
            {
                var department = await _DepartmentService.GetDepartmentAsync(departmentName);
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
        public async Task<IActionResult> Put(string departmentId, [FromBody] DepartmentDto departmentDto)
        {
                try
                {
                    if (departmentId != null)
                    {
                        var department = await _DepartmentService.GetDepartmentAsync(
                            departmentDto.departmentId);
                        await _DepartmentService.UpdateDepartmentAsync(departmentId, 
                            _mapper.Map<tDepartment>(departmentDto));
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
