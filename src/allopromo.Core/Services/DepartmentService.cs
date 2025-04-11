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
    public class DepartmentService : // BaseService<Department>
        IDepartmentService
    {
        public IRepository<Department> _departmentRepository {get; set;}
        public DepartmentService(IRepository<Department> departmentRepository)//:base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #region Create
        public void Create()
        {
            try
            {
                _departmentRepository.Add(new Department
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
        public void Add(Department department)
        {
            _departmentRepository.Add(new Department { });
        }
        public async Task CreateDepartmentAsync(Department department)
        {
            try
            {
                Department department1 = new Department();
                department.departmentId = Guid.NewGuid().ToString();
                department.departmentName = "";
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
        public async Task<Department> GeDepartmentAsync(string Name)
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

        //public async Task<IEnumerable<Department>> GetEntities()
        //{
        //    IEnumerable<Department> tObjs = null;
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

        public async Task<IEnumerable<Department>> GeDepartmentsAsync()
        {
            IEnumerable<Department> departments = null;
            try
            {
                var departmentsObj = await _departmentRepository.GetAllAsync();// GetEntitiesAsync();
                departments = AutoMapper.Mapper.Map<IEnumerable<Department>>(departmentsObj.AsEnumerable());
            }
            catch (Exception)
            {

                throw;
            }
            return departments;

            //IEnumerable<Department> tEntities = null;
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

        public Task<Department> GeDepartmentAsync(Guid departmentId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Update
        public async Task<Department> UpdateDepartmentAsync(string departmentId,
            Department department
            )
        {
            var tObj = await _departmentRepository.GetByIdAsync(departmentId);

            department.departmentName = tObj.departmentName;
            department.departmentThumbnail = tObj.departmentThumbnail;

            _departmentRepository.Update(department);
            //departmentDto = AutoMapper.Mapper.Map<DepartmentDto>(department);

            return tObj;
        }
        public async Task<Department> UpdateDepartmentAsync(Department department, 
            Department departmentDto
            )
        {
            department = await _departmentRepository.GetByIdAsync(department.departmentId);
            department.departmentName = departmentDto.departmentName;
            department.departmentThumbnail = departmentDto.departmentThumbnail;

            //Department.Categories = department.
            //department.departmentId = departmentId;
            //department

            _departmentRepository.Update(department);

            departmentDto = AutoMapper.Mapper.Map<Department>(department);
            return departmentDto;
        }
        #endregion

        #region Delete
        Task<Department> IDepartmentService.DeleteDepartmentAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
