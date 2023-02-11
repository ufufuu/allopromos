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
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperProfileCore>();
            });
        }
        public async Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync()
        {
            var tDepartments = await GetEntities();
            var departments = AutoMapper.Mapper.Map<IEnumerable<DepartmentDto>>(tDepartments);
            return departments;

            IEnumerable<tDepartment> tEntities = null;
            IEnumerable<DepartmentDto> departmentsDto= null;
            try
            {
                var de = _departmentRepository;
                tEntities = await _departmentRepository.GetAllAsync();
                departments = AutoMapper.Mapper.Map<IEnumerable<DepartmentDto>>(tEntities);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException();
            }
            return departments;
        }
        //public override async Task<IEnumerable<tDepartment>> GetEntities()
        public async Task<IEnumerable<tDepartment>> GetEntities()
        {
            IEnumerable <tDepartment> tEntities = null;
            IEnumerable<DepartmentDto> departments = null;
            try
            {
                var de = _departmentRepository;
                tEntities = await _departmentRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw new NullReferenceException();
            }
            return tEntities;
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
        public new void Add(tDepartment department)
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
