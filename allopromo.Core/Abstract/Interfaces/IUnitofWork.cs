using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Core.Abstract
{
    public interface IUnitofWork
    {
        //private IRepository<TEntity>
        void Save();
    }
}
