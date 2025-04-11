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
        public string departmentThumbnail { get; set; }
        public string createdDate { get; set; }
        public string updatedDate { get; set; }
        public static DepartmentDto ToDepartmentDto(tDepartment department)
        {
            DepartmentDto dto = new DepartmentDto();
            dto.departmentId = department.departmentId;
            dto.departmentName = department.departmentName;
            dto.createdDate = department.createdDate.ToString();
            dto.updatedDate = department.updatedDate.ToString();

            //dto.departmentImage = department.departmentThumbnail;

            return dto;
        }
    }
}
