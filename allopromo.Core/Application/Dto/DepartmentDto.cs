using allopromo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Application.Dto
{
    public class DepartmentDto
    {
        public string departmentId { get; set; }
        public string departmentName { get; set; }

        public static DepartmentDto ToDepartmentDto(tDepartment department)
        {
            DepartmentDto dto = new DepartmentDto();
            dto.departmentId = department.departmentId;
            dto.departmentName = department.departmentName;
            return dto;
        }
    }
}
