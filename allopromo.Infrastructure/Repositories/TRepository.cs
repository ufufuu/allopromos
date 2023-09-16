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
    public class TRepository<T> : IRepository<T> where T : class
        // Unit of Work ? que doit retourner creeer categry ?
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        private DbSet<T> _table;
        #endregion

        #region Constructors

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
        #endregion

        #region Create
        public void Add(T obj)
        {
            try
            {
                _table.Add(obj);
                //using (var dbContext = new AppDbContext())
                //{
                    _dbContext.SaveChanges();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task Add2(T obj)
        {
            if (obj != null)
            {
                using (var dbContext = new AppDbContext())
                {
                    try
                    {
                        dbContext.Entry<T>(obj);
                        dbContext.SaveChanges();
                        return obj as Task;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                }
            }
            else
            {
                throw new ArgumentNullException("obj");
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
        #endregion

        #region Read
        public Task<List<T>> GetAllAsync()
        {
            var tObjects = _table.ToListAsync();
            if (tObjects != null)
                return tObjects;
            else
                throw new ArgumentNullException();
        }
        public Task<IEnumerable<T>> GetEntitiesAsync()
        {
            var tObj = _dbContext.Set<T>();
            return (Task.FromResult(tObj.AsEnumerable()));
        }
        public IQueryable<T> GetByIdAsync(int categoryId, int pageNumber, int offSet)
        {
            return null;
        }
        public Task<T> GetByIdAsync(string Id)
        {
            //return _table.FindAsync(Id.ToString());  // Why Not Guid.Parse(Id) here ?

            var tObj = (Task.FromResult(_table.Find(Id.ToString())));
            return tObj;
        }
        public async Task<T> GetByName(string Name)
        {
            return await _table.FindAsync();
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
        #endregion

        #region Update
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
        #endregion

        #region Delete
        public bool Delete(object Id)
        {
            T obj = _table.Find(Id);
            _table.Remove(obj);
            return true;
        }
        public void Delete(T obj)
        {
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
