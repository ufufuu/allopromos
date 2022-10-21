using allopromo.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Infrastructure.Data.Repository
{
    public class UnitofWork:IUnitofWork
    {
        public void Save()
        {
        }
    }
}









// Unit of Work +_ Repository Pattern  ->

//https://enlabsoftware.com/development/how-to-build-and-deploy-a-three-layer-architecture-
//application-with-c-sharp-net-in-practice.html

//?

/*public interface IReporitory<TEntity> where TEntity : class 
{
    void Add(TEntity entity);
    void Remove(TEntity entity);
    TEntity Get(int id);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
}

*/
