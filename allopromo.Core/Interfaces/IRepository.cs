using allopromo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace allopromo.Core.Abstract
{
    public class StoreRepository3:IEntityBaseRepository<tStore>
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

        }
    }
    public class Repository <T> where T:class//,  IRepository<T> where T:class 
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
    public interface IEntityBaseRepository<TDomain> where TDomain:class, new()
    {
        //abstract List<tStore> GetStores();
        void Insert(TDomain obj);
        void Update(TDomain obj);
        void Delete(TDomain obj);
        TDomain Get();
        IEnumerable<TDomain> GetAll();
        TDomain GetBy();
    }
    public interface IGenericsRepository<T> where T:class
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        T Get();
        IEnumerable<T> GetAll();
        T GetBy();
    }
    public class GenericRepository<T> where T:class //: IGenericsRepository<T>
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
    public class GenericRepositoryFactory<T> where T:class
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