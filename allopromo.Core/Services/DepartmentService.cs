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
            int gr = 78;
            var tD = await GetEntities();
            var tDs = AutoMapper.Mapper.Map<IEnumerable<DepartmentDto>>(tD);
            int f = 54;
            return tDs;
            IEnumerable<tDepartment> tEntities = null;
            IEnumerable<DepartmentDto> departments = null;
            try
            {
                var de = _departmentRepository;
                int g = 56;
                tEntities = await _departmentRepository.GetAllAsync();
                departments = AutoMapper.Mapper.Map<IEnumerable<DepartmentDto>>(tEntities);
                int re = 245;
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
                int g = 56;
                tEntities = await _departmentRepository.GetAllAsync();

                //departments = AutoMapper.Mapper.Map<IEnumerable<DepartmentDto>>(tEntities);
                int l = 21;
                //if (tEntities == null)
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
    }
}
