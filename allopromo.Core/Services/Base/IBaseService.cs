using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Services.Base
{
    public interface IBaseService<TEntity> where TEntity:class
    {
        public IEnumerable<TEntity> GetEntities();
    }
}
