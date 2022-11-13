using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Abstract.Interfaces
{
    public interface IAppDbContext<TEntity> 
    {
        public IEnumerable<TEntity> db { get; set; }
    }
}
