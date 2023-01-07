using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Services.Base
{
    public class BaseService<TEntity>: IBaseService<TEntity> where TEntity:class
    {
        IRepository<TEntity> _departmentRepo;
        public BaseService()
        {
        }
        public BaseService(IRepository<TEntity> departmentRepo)
        {
            if(_departmentRepo != null)
            _departmentRepo = departmentRepo;
        }
        public void Add(TEntity entity)
        {
            if(_departmentRepo !=null)
            _departmentRepo.Add(entity);
        }
        public async Task<IEnumerable<TEntity>> GetEntities()
        {
            return await _departmentRepo.GetAllAsync();
        }
        
        public void Create(TEntity entity)                         //string Id)
        {
            if (entity!= null)
            {
                _departmentRepo.Add(entity);
            }
        }
    }
}
