using allopromo.Core.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Services.Base
{
    public interface IBaseService<TEntity> where TEntity:class
    {
        Task<IEnumerable<TEntity>> GetEntities();

        public abstract int Create(TEntity entity);
        public int Delete(TEntity tEntity);

        Task<object> GetById(string Id);
        void Save(TEntity entity);
    }
}
