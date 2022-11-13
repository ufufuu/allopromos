using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Services.Base
{
    public class BaseService<TEntity>: IBaseService<TEntity> where TEntity:class
    {
        public BaseService()
        {
        }
        public IEnumerable<TEntity> GetEntities()
        {
            return null;
        }
    }
}
