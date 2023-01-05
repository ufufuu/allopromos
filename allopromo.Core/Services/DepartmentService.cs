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
    public class DepartmentService<TEntity> : IBaseService<TEntity> where TEntity : DepartmentDto
        //: BaseService<TEntity> where TEntity : DepartmentDto
    {
        public IRepository<tDepartment> _departmentRepo;

        //public Enum DEPARTMENT_STATUS = ACTif, Inactif, Publie, Cree - 
        //public categoriesService {get;set;}
        //public enclosedFileService {get; set;} //public approvalService 

        #region "Proprietes & Constantes"
        private const string SUJET_TRNASCTIon_REUSE = "TRrans Refuse";
        #endregion

        #region "Constructeurs & Methodes de Base"
        public DepartmentService(IRepository<tDepartment> departmentRepo) //: base(repo)
        {
            _departmentRepo = departmentRepo;
        }
        public int Create(TEntity entity)
        {
            if (entity != null)
            {
                try
                {
                    var tObj = new tDepartment();
                    tObj.departmentId = Guid.NewGuid().ToString();
                    tObj.departmentName = entity.departmentName;
                    tObj.categories = null;

                    tObj.categories = new List<tStoreCategory>
                    {
                        new tStoreCategory
                        {
                              storeCategoryId=Guid.NewGuid(),
                        },
                         new tStoreCategory
                        {
                             storeCategoryId=Guid.NewGuid(),
                        },
                    };
                    var department = AutoMapper.Mapper.Map<tDepartment>(entity);
                    _departmentRepo.Add(tObj);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return 0;
        }
        public void CreateDepartement(DepartmentDto departmentDto)
        {
            if (departmentDto != null)
            {
                try
                {
                    var department = AutoMapper.Mapper.Map<tDepartment>(departmentDto);
                    _departmentRepo.Add(department);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public async Task<IEnumerable<TEntity>> GetEntites()
        {
            IEnumerable<DepartmentDto> departments = new List<DepartmentDto>();
            try
            {
                var tEntities = await _departmentRepo.GetAllAsync();
                departments = AutoMapper.Mapper.Map<IEnumerable<DepartmentDto>>(tEntities);
            }
            catch (Exception)
            {
                throw;
            }
            return (IEnumerable<TEntity>)departments;
        }

        public async Task<IEnumerable<TEntity>> GetEntities()
        {
            IEnumerable<DepartmentDto> departments = new List<DepartmentDto>();
            try
            { 
                var tEntities = await  _departmentRepo.GetAllAsync();
                departments = AutoMapper.Mapper.Map<IEnumerable<DepartmentDto>>(tEntities);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return (IEnumerable<TEntity>)departments;
        }
        Task<object> IBaseService<TEntity>.GetById(string Id)
        {
            var tObj = new Object();
            tObj = _departmentRepo.GetByIdAsync(Id);
            return (Task<object>)tObj;
        }
        void IBaseService<TEntity>.Save(TEntity entity)
        {
            _departmentRepo.Save();
        }
        int IBaseService<TEntity>.Delete(TEntity tEntity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region "Methodes pour DtO"
        #endregion

        #region "Methodes Specifiques"
        #endregion

        #region "Validations"
        #endregion
    }
}
