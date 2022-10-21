using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using allopromo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Infrastructure.Repositories
{
    public class TRepository<T> : IRepository<T> where T : class        /// Unit of Work ? que doit retourner creeer categry ?
    {
        #region fields
        private readonly AppDbContext _dbContext;
        private DbSet<T> _table;
        #endregion
        #region Public Method
        public TRepository(AppDbContext dbContext)
        {
            //_table = _dbContext.Set<T>();

            _dbContext = dbContext;
            _table = dbContext.Set<T>();
        }
        public TRepository(AppDbContext dbContext, DbSet<T> table)
        {
            _dbContext = dbContext;
            _table = table;
        }
        public Task Add(T obj)
        {
            if (obj != null)
            {
                _dbContext.Entry<T>(obj);
                this.Save();
                return obj as Task;
            }
            throw new  NullReferenceException();
        }
        Task IRepository<T>.Add(T obj, string imageUrl)
        {
            if (obj != null)
            {
                _dbContext.Add(obj);
                this.Save();
            }
            else
            {
                throw new NullReferenceException();
            }
            return Task.FromResult(obj);
        }
        Task IRepository<T>.Add(string obj, string imageUrl)
        {
            if (obj == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                _dbContext.Add(obj);
            }
            return Task.FromResult(obj);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void Update(T obj)
        {
            _table.Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
        }
        public Task<List<T>> GetAllAsync() ////Task<List<T>> IRepository<T>.GetAllAsync()
        {
            return _table.ToListAsync();
        }
        Task<T> IRepository<T>.GetByIdAsync(int categoryId, int pageNumber, int offSet)
        {
            throw new NotImplementedException();
        }
        public async Task<T> GetByIdAsync(int Id)
        {
            return await _table.FindAsync(Id);
        }
        public bool Delete(object Id) //void IRepository<T>.Delete(object Id)
        {
            T obj = _table.Find(Id);
            _table.Remove(obj);
            return true;
        }
        void IRepository<T>.Update(T obj)
        {
            throw new NotImplementedException();
        }
        Task<T> IRepository<T>.GetByIdAsync(object Id)
        {
            throw new NotImplementedException();
        }
        Task<ProductDto> IRepository<T>.CreateProductAsync(tProduct product)
        {
            throw new NotImplementedException();
        }
        Task<ProductDto> IRepository<T>.GetProductAsync(string productId)
        {
            throw new NotImplementedException();
        }
        Task<IEnumerable<ProductDto>> IRepository<T>.GetProductsByStoreIdAsync(string Id)
        {
            throw new NotImplementedException();
        }
        void IRepository<T>.DeleteStoreCategory(T obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}//Generics : code reuse - type safety - performance - 


/*public class StoreRepository3:IEntityBaseRepository<tStore>
    {
        public void Delete(tStore obj)
        {
            throw new NotImplementedException();
        }

        public tStore Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tStore> GetAll()
        {
            throw new NotImplementedException();
        }

        public tStore GetBy()
        {
            throw new NotImplementedException();
        }

        public void Insert(tStore obj)
        {
            throw new NotImplementedException();
        }

        public void Update(tStore obj)
        {
            throw new NotImplementedException();
        }

        void GetStoresAsync()
        {
            //using(var db = new AppDbContext())
           //{
                //var query8 = from q in db.Users
                //    select new
                //    {
                //       Id = q.Email,
                //    } 
                //    into rtrt
                //      where rtrt.Id=="0"
                //         select new
                //    {
                //    };
           // }



            //var query7= AppDbContex
           /* var query= from ct in AppDbContext.CT
                       where ct.DateDebut < dateDemande
                       ....
                       join pct in AppDbContext.PCT
                       on ct.ID equals pct.ID
                       where pct.CT_ID equals parametreRecu
                       orderby pct.pct_ordreParametres ascending 
                       select new tempClass { } as tempObj
                       {
                           ChampConcatene = pct.CleParametres+","
                       }
                        
                        join ta in AppDbContext.TA
                        Select{
                            tarifId= ta.Id,
                            tarifMontant= ta.Montant
                        }
                    */
/*
        }
    }
    public class Repository<T> where T : class//,  IRepository<T> where T:class 
{
    private readonly AppDbContext _dbContext;
    public Repository()
    {
        //_dbContext = new AppDbContext();
    }

    public void CreateUser(ApplicationUser user, string password)
    {
    }
    public void CreateUserr(ApplicationUser user, string password)
    {
        throw new NotImplementedException();
    }
    public void Delete(tStore storeId)
    {
        throw new NotImplementedException();
    }
    public void DeleteUser()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ApplicationUser> GeApplicationUsers()
    {
        throw new NotImplementedException();
    }
    public ApplicationRole GetRole()
    {
        throw new NotImplementedException();
    }
    public List<ApplicationRole> GetRoles()
    {
        throw new NotImplementedException();
    }
    public tStore GetStoreById(string storeId)
    {
        throw new NotImplementedException();
    }

    public List<tStore> GetStores()
    {
        throw new NotImplementedException();
    }
    public ApplicationUser GetUser()
    {
        throw new NotImplementedException();
    }
    public IEnumerable<ApplicationUser> GetUsers()
    {
        var users = (IEnumerable<ApplicationUser>)_dbContext.Users.ToList();
        return users;
    }
    public void Insert(tStore store)
    {
        if (store == null)
            throw new Exception();
        else
        {
            _dbContext.Stores.Add(store);
            _dbContext.SaveChanges();
        }
    }
    public void Save()
    {
        throw new NotImplementedException();
    }
    public void Update(tStore store)
    {
        throw new NotImplementedException();
    }

    public void UpdateUser()
    {
        throw new NotImplementedException();
    }
}
public interface IEntityBaseRepository<TDomain> where TDomain : class, new()
{
    //abstract List<tStore> GetStores();
    void Insert(TDomain obj);
    void Update(TDomain obj);
    void Delete(TDomain obj);
    TDomain Get();
    IEnumerable<TDomain> GetAll();
    TDomain GetBy();
}
public interface IGenericsRepository<T> where T : class
{
    void Insert(T obj);
    void Update(T obj);
    void Delete(T obj);
    T Get();
    IEnumerable<T> GetAll();
    T GetBy();
}
public class GenericRepository<T> where T : class //: IGenericsRepository<T>
{
    private readonly AppDbContext _appDbContext;

    private AppDbContextFactory _dbContext;
    public void Delete(T obj)
    {
        throw new NotImplementedException();
    }

    public T Get()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetAll()
    {
        throw new NotImplementedException();
    }
    public T GetBy()
    {
        throw new NotImplementedException();
    }
    public void Insert(T obj)
    {
        throw new NotImplementedException();
    }
    public void Update(T obj)
    {
        throw new NotImplementedException();
    }
}
public class GenericRepositoryFactory<T> where T : class
{
    public static GenericRepository<T> GetRepository()
    {
        return new GenericRepository<T>();
    }
}
}
//Factory Pattern --- vs fctory method vs abstract factory 
//sql having vs where

//public interface IRepository<T> where T : class
//{
//}
//public interface IStoreRepository
//{
//    List<tStore> GetStores();
//    public tStore GetStoreById(string storeId);
//    public void Insert(tStore store);
//    public void Update(tStore store);
//    public void Delete(tStore storeId);
//    public void Save();
//}

//public class RoleRepository : IModelRepository
//public class RoleRepository : BaseRepository
//{
//    // Combine Above repo  Class to Generic Type Repositories !?
//    private AppDbContext _dbContext { get; set; }
//    public RoleRepository()
//    {
//        _dbContext = new AppDbContext();
//    }
//    public RoleRepository(AppDbContext dbContext)
//    {
//        _dbContext = dbContext;
//    }
//    public List<ApplicationRole> GetRoles()
//    {
//        using (var dbContext = new AppDbContext())
//        {
//            //return _dbContext.Roles.AsEnumerable().ToList();

//            return null;
//        }

//        /*if(_dbContext!=null)            
//            return _dbContext.Roles.AsEnumerable().ToList();
//        return null;
//        */
//    }
//    public string GetRole()
//    {
//        return "Admin";
//    }
//    //tRole IModelRepository.GetRole()
//    //{
//    //    throw new NotImplementedException();
//    //}
//}
//public enum EnumRole
//{
//    // to derive from Role ? to extend Role
//}
// ? Model vs Domain ( domain object ! - )
