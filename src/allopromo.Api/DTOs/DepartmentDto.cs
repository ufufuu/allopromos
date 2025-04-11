using allopromo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Api.DTOs
{
    public class DepartmentDto
    {
        public string departmentId { get; set; }

        public string departmentName { get; set; }

        public string departmentThumbnail { get; set; }

        public string createdDate { get; set; }

        public string updatedDate { get; set; }
    }
}
