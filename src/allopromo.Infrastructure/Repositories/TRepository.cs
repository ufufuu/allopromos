using allopromo.Core.Abstract;
using allopromo.Core.Entities;
using allopromo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Infrastructure.Repositories ///allopromo.Infrastructure.Repositories
{
    public class TRepository<T> : IRepository<T> where T : class
        // Unit of Work ? que doit retourner creeer categry ?
    {
        #region Fields
        private readonly ApplicationDbContext _dbContext;
        private DbSet<T> _table;
        #endregion

        #region Constructors

        public TRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<T>();
        }
        public TRepository(ApplicationDbContext dbContext, DbSet<T> table)
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
            if ((object)obj == null)
                throw new ArgumentNullException(nameof(obj));
            using (ApplicationDbContext applicationDbContext = new ApplicationDbContext())
            {
                try
                {
                    applicationDbContext.Entry<T>(obj);
                    applicationDbContext.SaveChanges();
                    return (object)obj as Task;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        Task IRepository<T>.Add(string obj, string imageUrl)
        {
            if (obj == null)
                throw new NullReferenceException();
            this._dbContext.Add<string>(obj);
            return (Task)Task.FromResult<string>(obj);
        }
        public void Save() => this._dbContext.SaveChanges();

        public Task<List<T>> GetAllAsync()
        {
            return this._table.ToListAsync<T>() ?? throw new ArgumentNullException();
        }

        public Task<IEnumerable<T>> GetEntitiesAsync()
        {
            return Task.FromResult<IEnumerable<T>>(this._dbContext.Set<T>().AsEnumerable<T>());
        }

        public IQueryable<T> GetByIdAsync(int categoryId, int pageNumber, int offSet)
        {
            return (IQueryable<T>)null;
        }

        public Task<T> GetByIdAsync(string Id)
        {
            return Task.FromResult<T>(this._table.Find((object)Id.ToString()));
        }

        public async Task<T> GetByName(string Name) => await this._table.FindAsync();

        public async Task<T> GetByIdAsync(int Id)
        {
            return await this._table.FindAsync((object)Id.ToString());
        }

        async Task<T> IRepository<T>.GetByIdAsync(object Id)
        {
            return await this._table.FindAsync((object)Id.ToString());
        }

        public void Update(T obj)
        {
            if ((object)obj == null)
                return;
            this._table.Attach(obj);
            this._dbContext.Entry<T>(obj).State = EntityState.Modified;
        }

        void IRepository<T>.Update(T obj)
        {
            this.GetByIdAsync(obj.GetHashCode());
            this._dbContext.Entry<T>(obj).State = EntityState.Modified;
            this._dbContext.Entry<T>(obj).CurrentValues.SetValues((object)obj);
            this._dbContext.SaveChanges();
        }

        public bool Delete(object Id)
        {
            this._table.Remove(this._table.Find(Id));
            return true;
        }

        public void Delete(T obj)
        {
        }

        public Task Add(T obj, string imageUrl)
        {
            throw new NotImplementedException();
        }
    }


    //Task<ProductDto> IRepository<T>.GetProductAsync(string productId)
    //Task<IEnumerable<ProductDto>> IRepository<T>.GetProductsByStoreIdAsync(string Id)
    //void IRepository<T>.DeleteStoreCategory(T obj)
    #endregion
}


















//Generics : code reuse - type safety - performance -
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
