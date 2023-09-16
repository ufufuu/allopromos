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
        Task<DepartmentDto> CreateDepartmentAsync(DepartmentDto departmentDto);
    #endregion

    #region Read
        Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync();
        Task<DepartmentDto> GetDepartmentAsync(string departmentName); //GetDepartmentAsync
        Task<DepartmentDto> GetDepartmentAsync(Guid departmentId);
        Task<DepartmentDto> GetDepartmentAsync(int departmentReference);
        Task<IEnumerable<tDepartment>> GetEntities();
        #endregion

    #region Update
    public Task<DepartmentDto> UpdateDepartmentAsync(tDepartment department, DepartmentDto departmentDto);
    public Task<DepartmentDto> UpdateDepartmentAsync(string departmentID, DepartmentDto departmentDto);
        #endregion

        #region Delete
        Task<DepartmentDto> DeleteDepartmentAsync();
    #endregion
    }
}
