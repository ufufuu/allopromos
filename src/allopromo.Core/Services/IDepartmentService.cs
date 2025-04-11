


using allopromo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace allopromo.Core.Services
{
    public interface IDepartmentService
    {
    #region Create
        Task CreateDepartmentAsync(Department department);
    #endregion

    #region Read
        Task<IEnumerable<Department>> GeDepartmentsAsync();
        Task<Department> GeDepartmentAsync(string departmentName); //GeDepartmentAsync
        Task<Department> GeDepartmentAsync(Guid departmentId);

        //Task<IEnumerable<Department>> GetEntities();

    #endregion

    #region Update

    //public Task<Department> UpdateDepartmentAsync(Department department, Department departmentDto);

    public Task<Department> UpdateDepartmentAsync(string departmentID, Department departmentDto);

    #endregion


    #region Delete
    Task<Department> DeleteDepartmentAsync();
    #endregion

    }
}
