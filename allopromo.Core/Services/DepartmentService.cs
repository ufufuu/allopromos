using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using allopromo.Core.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync();
        Task<DepartmentDto> GetDepartmentAsync();


        Task<DepartmentDto> CreateDepartmentAsync();
        Task<DepartmentDto> DeleteDepartmentAsync();
    }
    public class DepartmentService  :// BaseService<tDepartment>
        IDepartmentService
    {
        public IRepository<tDepartment> _departmentRepository { get; set; }
        public DepartmentService(IRepository<tDepartment> departmentRepository) //:base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync()
        {
            IEnumerable<DepartmentDto> departmentsDto = null;

            //var tDepartments = await GetEntities();

            var departmentsObj = await _departmentRepository.GetEntitiesAsync();
            var g = 7;
            var department = AutoMapper.Mapper.Map<IEnumerable<DepartmentDto>>(departmentsObj.AsEnumerable());

            return department;

            IEnumerable <tDepartment> tEntities = null;
            
            try
            {
                tEntities = await _departmentRepository.GetAllAsync();
                var tObjs = tEntities.AsQueryable();
                departmentsDto = AutoMapper.Mapper.Map<IEnumerable<DepartmentDto>>(tEntities);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return departmentsDto;
        }
        public async Task<IEnumerable<tDepartment>> GetEntities()
        {
            IEnumerable <tDepartment> tObjs = null;
            try
            {
                var de = _departmentRepository;
                tObjs = await _departmentRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tObjs;
        }
        public void Create()
        {
            try
            {
                _departmentRepository.Add(new tDepartment
                {
                    departmentId = Guid.NewGuid().ToString(),
                    departmentName = "",
                    departmentThumbnail = ""
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Add(tDepartment department)
        {
            _departmentRepository.Add(new tDepartment { });
        }
        Task<DepartmentDto> IDepartmentService.GetDepartmentAsync()
        {
            throw new NotImplementedException();
        }

        Task<DepartmentDto> IDepartmentService.CreateDepartmentAsync()
        {
            throw new NotImplementedException();
        }

        Task<DepartmentDto> IDepartmentService.DeleteDepartmentAsync()
        {
            throw new NotImplementedException();
        }
    }
}
