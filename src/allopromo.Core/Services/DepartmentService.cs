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
        public IRepository<tDepartment> _departmentRepository {get; set;}
        public DepartmentService(IRepository<tDepartment> departmentRepository)//:base(departmentRepository)
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
        public async Task CreateDepartmentAsync(DepartmentDto departmentDto)
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
                    return; // Task.FromResult(departmentDto);// Dto);
                }
                else
                    throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Read
        public async Task<tDepartment> GetDepartmentAsync(string Name)
        {
            try
            {
                var departmentObj = await _departmentRepository.GetByIdAsync(Name);
                //return AutoMapper.Mapper.Map<DepartmentDto>(departmentObj);

                return departmentObj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task<IEnumerable<tDepartment>> GetEntities()
        //{
        //    IEnumerable<tDepartment> tObjs = null;
        //    try
        //    {
        //        var de = _departmentRepository;
        //        tObjs = await _departmentRepository.GetAllAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return tObjs;
        //}

        public async Task<IEnumerable<tDepartment>> GetDepartmentsAsync()
        {
            IEnumerable<tDepartment> departments = null;
            try
            {
                var departmentsObj = await _departmentRepository.GetAllAsync();// GetEntitiesAsync();
                departments = AutoMapper.Mapper.Map<IEnumerable<tDepartment>>(departmentsObj.AsEnumerable());
            }
            catch (Exception)
            {

                throw;
            }
            return departments;

            //IEnumerable<tDepartment> tEntities = null;
            //try
            //{
            //    tEntities = await _departmentRepository.GetAllAsync();
            //    var tObjs = tEntities.AsQueryable();

            //    //departmentsDto = AutoMapper.Mapper.Map<IEnumerable<DepartmentDto>>(tEntities);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //return departments;
        }

        public Task<tDepartment> GetDepartmentAsync(Guid departmentId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Update
        public async Task<tDepartment> UpdateDepartmentAsync(string departmentId,
            tDepartment department
            )
        {
            var tObj = await _departmentRepository.GetByIdAsync(departmentId);

            department.departmentName = tObj.departmentName;
            department.departmentThumbnail = tObj.departmentThumbnail;

            _departmentRepository.Update(department);
            //departmentDto = AutoMapper.Mapper.Map<DepartmentDto>(department);

            return tObj;
        }
        public async Task<tDepartment> UpdateDepartmentAsync(tDepartment department, 
            tDepartment departmentDto
            )
        {
            department = await _departmentRepository.GetByIdAsync(department.departmentId);
            department.departmentName = departmentDto.departmentName;
            department.departmentThumbnail = departmentDto.departmentThumbnail;

            //tDepartment.Categories = department.
            //department.departmentId = departmentId;
            //department

            _departmentRepository.Update(department);

            departmentDto = AutoMapper.Mapper.Map<tDepartment>(department);
            return departmentDto;
        }
        #endregion

        #region Delete
        Task<tDepartment> IDepartmentService.DeleteDepartmentAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
