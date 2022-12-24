using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using allopromo.Core.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Services
{
    public class DepartmentService : BaseService<tDepartment>  //  !!!
    {
        private IRepository<tDepartment> _departmentRepository;
        public DepartmentService()
        {
        }
        public DepartmentService(IRepository<tDepartment> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
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
        public IEnumerable<DepartmentDto> GetEntities()
        {
            return null;
        }
    }
}
