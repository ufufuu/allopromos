using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Services.Base
{
    //public class BaseService<TEntity>: IBaseService<TEntity> where TEntity:class
    //{
    //    public IRepository<TEntity> _repo { get; set; }
    //    public BaseService(IRepository<TEntity> repo)
    //    {
    //        _repo = repo;
    //    }
    //    public void Create(TEntity entity) => _repo.Add(entity);

    //    public int Delete(TEntity entity) 
    //    {
    //        return 0;
    //    }
    //    public async Task<IEnumerable<TEntity>> GetEntites()
    //    {
    //        var tObjects = await _repo.GetAllAsync();
    //        return tObjects;
    //    }
    //    int IBaseService<TEntity>.Create(TEntity entity)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public virtual async Task<IEnumerable<TEntity>> GetEntities() => await _repo.GetAllAsync();
    //    int IBaseService<TEntity>.Delete(TEntity tEntity)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    Task<object> IBaseService<TEntity>.GetById(string Id)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    void IBaseService<TEntity>.Save(TEntity entity)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
