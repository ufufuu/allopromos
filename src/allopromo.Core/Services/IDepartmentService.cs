


using allopromo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace allopromo.Core.Services
{
    public interface IDepartmentService
    {
        Task CreateDepartmentAsync(Department departmentDto);

        Task<IEnumerable<Department>> GetDepartmentsAsync();

        Task<Department> GetDepartmentAsync(string departmentName);

        Task<Department> GetDepartmentAsync(Guid departmentId);

        Task<Department> UpdateDepartmentAsync(string departmentID, Department departmentDto);

        Task<Department> DeleteDepartmentAsync();

    }
}
