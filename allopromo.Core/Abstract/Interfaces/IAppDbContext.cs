using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Abstract.Interfaces
{
    public interface IAppDbContext<TEntity> //: AppDbContext<TEntity> where TEntity:class
    {
        public IEnumerable<TEntity> db { get; set; }
    }
}
