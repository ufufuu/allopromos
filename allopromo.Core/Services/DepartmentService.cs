using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using allopromo.Core.Services.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Services
{
    public class DepartmentService : // BaseService<tDepartment>
        IDepartmentService
    {
        public IRepository<tDepartment> _departmentRepository { get; set; }
        public DepartmentService(IRepository<tDepartment> departmentRepository) //:base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #region Create
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
        public async Task<DepartmentDto> CreateDepartmentAsync(DepartmentDto departmentDto)
        {
            try
            {
                tDepartment department = new tDepartment();
                department.departmentId = Guid.NewGuid().ToString();
                department.departmentName = departmentDto.departmentName;
                department.createdDate = System.DateTime.Now;
                department.updatedDate = null;
                if (department != null)
                {
                    _departmentRepository.Add(department);
                    return await Task.FromResult(departmentDto);
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Read
        public async Task<DepartmentDto> GetDepartmentAsync(string Name)
        {
            try
            {
                var departmentObj = await _departmentRepository.GetByIdAsync(Name);
                
                return AutoMapper.Mapper.Map<DepartmentDto>(departmentObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync()
        {
            IEnumerable<DepartmentDto> departmentsDto = null;

            var departmentsObj = await _departmentRepository.GetEntitiesAsync();
            var g = 7;
            var department = AutoMapper.Mapper.Map<IEnumerable<DepartmentDto>>(departmentsObj.AsEnumerable());
            return department;
            IEnumerable<tDepartment> tEntities = null;
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
            IEnumerable<tDepartment> tObjs = null;
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
        public Task<DepartmentDto> GetDepartmentAsync(Guid departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentDto> GetDepartmentAsync(int departmentReference)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public async Task<DepartmentDto> UpdateDepartmentAsync(string departmentId,
            DepartmentDto departmentDto
            )
        {
            var department = await _departmentRepository.GetByIdAsync(departmentId);

            department.departmentName = departmentDto.departmentName;
            department.departmentThumbnail = departmentDto.departmentThumbnail;

            _departmentRepository.Update(department);
            departmentDto = AutoMapper.Mapper.Map<DepartmentDto>(department);
            return departmentDto;
        }
        public async Task<DepartmentDto> UpdateDepartmentAsync(tDepartment department, 
            DepartmentDto departmentDto
            )
        {
            department = await _departmentRepository.GetByIdAsync(department.departmentId);
            department.departmentName = departmentDto.departmentName;
            department.departmentThumbnail = departmentDto.departmentThumbnail;

            //tDepartment.Categories = department.
            //department.departmentId = departmentId;
            //department

            _departmentRepository.Update(department);

            int g = 56;
            departmentDto = AutoMapper.Mapper.Map<DepartmentDto>(department);
            return departmentDto;
        }
        #endregion

        #region Delete
        Task<DepartmentDto> IDepartmentService.DeleteDepartmentAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
