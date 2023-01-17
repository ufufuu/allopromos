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
        public BaseService(IRepository<TEntity> departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }
        public BaseService()
        {
        }
        public void Add(TEntity entity)
        {
            if(_departmentRepo !=null)
            _departmentRepo.Add(entity);
        }
        public async Task<IEnumerable<TEntity>> GetEntities()
        {
            if (_departmentRepo != null)
                return await _departmentRepo.GetAllAsync();
            else
                throw new NullReferenceException();
        }
        public void Create(TEntity entity)
        {
            if (entity!= null)
            {
                _departmentRepo.Add(entity);
            }
        }
    }
}
