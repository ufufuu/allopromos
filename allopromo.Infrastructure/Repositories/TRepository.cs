using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using allopromo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Infrastructure.Repositories
{
    public class TRepository<T> : IRepository<T> where T : class /// Unit of Work ? que doit retourner creeer categry ?
    {
        #region fields
        private readonly AppDbContext _dbContext;
        private DbSet<T> _table;
        #endregion
        #region Public Method
        public TRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<T>();
        }
        public TRepository(AppDbContext dbContext, DbSet<T> table)
        {
            _dbContext = dbContext;
            _table = table;
        }
        public Task Add(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            else
            {
                _dbContext.Entry<T>(obj);
                this.Save();
                return obj as Task;
            }
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
        public Task<List<T>> GetAllAsync()////Task<List<T>> IRepository<T>.GetAllAsync()
        {
            var tObjects = _table.ToListAsync();
            var tObjects2 = _dbContext.Set<T>();
            int g = 5;
            return tObjects; //.ToListAsync();
        }
        public async Task<IEnumerable<tStoreCategory>> GetStoreCategoriesAsync()
        {
            var tCategories = await _dbContext.StoreCategories.ToListAsync();
            return tCategories;
        }
        public IQueryable<T> GetByIdAsync(int categoryId, int pageNumber, int offSet)
        {
            return null;
        }
        public async Task<T> GetByIdAsync(int Id)
        {
            return await _table.FindAsync(Id.ToString());
        }
        async Task<T> IRepository<T>.GetByIdAsync(object Id)
        {
            var obj = await _table.FindAsync(Id.ToString());
            return obj;
        }
        public async Task<T> GetByIdAsync(string Id)
        {
            return await _table.FindAsync(Guid.Parse(Id));
        }
        public bool Delete(object Id)
        {
            T obj = _table.Find(Id);
            _table.Remove(obj);
            return true;
        }
        public void Delete(T obj)
        {
        }
        public void Update(T obj)
        {
            if (obj != null)
            {
                //throw new ArgumentNullException();

                _table.Attach(obj);
                _dbContext.Entry(obj).State = EntityState.Modified;
            }
        }
        void IRepository<T>.Update(T obj)
        {
            var Id = GetByIdAsync(obj.GetHashCode());
            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.Entry(obj).CurrentValues.SetValues(obj);

            //_table.Update(obj);

            _dbContext.SaveChanges();
        }

        //Task<ProductDto> IRepository<T>.GetProductAsync(string productId)
        //Task<IEnumerable<ProductDto>> IRepository<T>.GetProductsByStoreIdAsync(string Id)
        //void IRepository<T>.DeleteStoreCategory(T obj)
        #endregion
    }

}//Generics : code reuse - type safety - performance -
/*
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

    public ApplicationRole GetRole()
    {
        throw new NotImplementedException();
    }
    public List<ApplicationRole> GetRoles()
    {
        throw new NotImplementedException();
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
