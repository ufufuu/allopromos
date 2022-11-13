using allopromo.Core.Abstract;
using allopromo.Core.Abstract.Interfaces;
using allopromo.Core.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Core.Model
{
    public class AccountMembershipService<TEntity>:BaseService <TEntity> where TEntity:class
    {
        public IAppDbContext<TEntity> db { get; set; }
        public IEnumerable<TEntity> GetEntities()
        {
            return null;
        }
    }
}

