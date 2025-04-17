
using allopromo.Api.DTOs;
using allopromo.Core.Abstract;
using allopromo.Core.Entities;
using allopromo.Core.Services;
using allopromo.Core.Services.Base;
using allopromo.Infrastructure.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace allopromo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public readonly IDepartmentService _DepartmentService;
        public IBaseService<DepartmentDto> _departmentService;
        private readonly IMapper _mapper;
        public readonly IConfiguration _config;
        public DepartmentController(
          IDepartmentService DepartmentService,
          IBaseService<DepartmentDto> departmentService,
          IMapper mapper,
          IConfiguration config)
        {
            _DepartmentService = DepartmentService;
            _departmentService = departmentService;
            _config = config;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentDto departmentDto)
        {
            try
            {
                if (departmentDto == null)
                    return BadRequest();
                var departmentObj = _mapper.Map<Department>(departmentDto);
                await _DepartmentService.CreateDepartmentAsync(departmentObj);
                return Ok(departmentDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetDepartments()
        {
            var departments= await _DepartmentService.GetDepartmentsAsync();
            if (departments != null)
                return Ok(departments);
            return NoContent();
        }

        [HttpGet]
        [Route("{departmentName}")]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetDepartmentByName(
          string departmentName)
        {
            DepartmentController departmentController = this;
            if (departmentName == null)
                return (ActionResult<IEnumerable<DepartmentDto>>)(ActionResult)departmentController.NotFound();
            Department departmentAsync = await departmentController._DepartmentService.GetDepartmentAsync(departmentName);
            return (ActionResult<IEnumerable<DepartmentDto>>)(ActionResult)departmentController.Ok((object)departmentAsync);
        }

        [HttpGet]
        [Route("cities+{cityId}")]
        public IActionResult GeTDepartmentById(string cityId)
        {
            try
            {
                return (IActionResult)this.Ok((object)string.Empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("departmentId")]
        public async Task<IActionResult> Put(string departmentId, [FromBody] DepartmentDto departmentDto)
        {
            if (departmentId == null || departmentDto == null)
                return BadRequest();

            var department = (await _departmentService.GetEntities()).FirstOrDefault();
            _departmentService.Update(department);
            return Ok(department);
        }

        [HttpDelete]
        [Route("department+{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            DepartmentController departmentController = this;
            IActionResult actionResult;
            try
            {
                (await departmentController._departmentService.GetEntities()).Select<DepartmentDto, DepartmentDto>((Func<DepartmentDto, DepartmentDto>)(c => c));
                actionResult = (IActionResult)departmentController.Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actionResult;
        }
    }
}
