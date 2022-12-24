using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Services.Base
{
    public interface IBaseService<TEntity> where TEntity:class
    {
        public Task<IEnumerable<TEntity>> GetEntities();
        
        //abstract int Add(TEntity baseEntity);
        //abstract int Add(List<TEntity> baseEntities);

        public void Create(TEntity entity);
    }
}
