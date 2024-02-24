
using allopromo.Core.Application.Dto;


using allopromo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace allopromo.Core.Services
{
    public interface IDepartmentService
    {
    #region Create
        Task CreateDepartmentAsync(DepartmentDto departmentDto);
    #endregion

    #region Read
        Task<IEnumerable<tDepartment>> GetDepartmentsAsync();
        Task<tDepartment> GetDepartmentAsync(string departmentName); //GetDepartmentAsync
        Task<tDepartment> GetDepartmentAsync(Guid departmentId);

        //Task<IEnumerable<tDepartment>> GetEntities();

    #endregion

    #region Update

    //public Task<tDepartment> UpdateDepartmentAsync(tDepartment department, tDepartment departmentDto);

    public Task<tDepartment> UpdateDepartmentAsync(string departmentID, tDepartment departmentDto);

    #endregion


    #region Delete
    Task<tDepartment> DeleteDepartmentAsync();
    #endregion

    }
}
