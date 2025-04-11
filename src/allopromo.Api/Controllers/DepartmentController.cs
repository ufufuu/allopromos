
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
        public readonly
#nullable disable
    IConfiguration _config;
        public readonly ApplicationDbContext _appDb;
        public readonly IDepartmentService _DepartmentService;
        public IBaseService<DepartmentDto> _departmentService;
        public readonly IRepository<Department> _deparmentRepository;
        private readonly IMapper _mapper;

        public DepartmentController(
          IDepartmentService DepartmentService,
          IBaseService<DepartmentDto> departmentService,
          IConfiguration config)
        {
            this._DepartmentService = DepartmentService;
            this._departmentService = departmentService;
            this._config = config;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentDto departmentDto)
        {
            DepartmentController departmentController = this;
            try
            {
                if (departmentDto == null)
                    return (IActionResult)departmentController.BadRequest();
                Department departmentDto1 = Mapper.Map<Department>((object)departmentDto);
                await departmentController._DepartmentService.CreateDepartmentAsync(departmentDto1);
                return (IActionResult)departmentController.Ok((object)departmentDto);
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
            DepartmentController departmentController = this;
            IEnumerable<Department> departmentsAsync = await departmentController._DepartmentService.GetDepartmentsAsync();
            return departmentsAsync == null ? (ActionResult<IEnumerable<DepartmentDto>>)(ActionResult)departmentController.NotFound() : (ActionResult<IEnumerable<DepartmentDto>>)(ActionResult)departmentController.Ok((object)departmentsAsync);
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
            DepartmentController departmentController = this;
            try
            {
                if (departmentId == null)
                    return (IActionResult)departmentController.NotFound();
                Department department = await departmentController._DepartmentService.GetDepartmentAsync(departmentDto.departmentId);
                Department department1 = await departmentController._DepartmentService.UpdateDepartmentAsync(departmentId, departmentController._mapper.Map<Department>((object)departmentDto));
                return (IActionResult)departmentController.Ok((object)department);
            }
            catch (Exception ex)
            {
                throw;
            }
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
