using allopromo.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Services.Base
{
    public interface IBaseService<TEntity> where TEntity:class
    {
        public abstract IRepository<TEntity> _Repository { get; set; }

        Task<IEnumerable<TEntity>> GetEntities();
        abstract void Add(TEntity baseEntity);
        
        public void Update(TEntity entity);
    }
}
