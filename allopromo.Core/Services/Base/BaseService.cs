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
        public IRepository<TEntity> _Repository { get; set; }
        public BaseService(IRepository<TEntity> Repository)
        {
            _Repository = Repository;
        }
        public virtual async Task<IEnumerable<TEntity>> GetEntities()
        {
            var tEntities = await _Repository.GetAllAsync();
                return tEntities;
        }
        public void Add(TEntity entity)
        {
            if (_Repository != null)
                _Repository.Add(entity);
        }
        public void Update(TEntity entity)
        {
            if (entity!= null)
            {
                _Repository.Add(entity);
            }
        }
    }
}
