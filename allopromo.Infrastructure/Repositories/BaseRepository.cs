using allopromo.Core.Domain;
using allopromo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Infrastructure.Data.Repository
{
    public abstract class BaseRepository
    {
        public virtual List<tStore> GetStores() 
            // ? What does extern modifier , adding a DLL import attribute to specc import ?
        {
            return null;
        }
        public virtual tStore GetStoreById(string storeId)
        {
            return null;
        }
        public virtual void Insert(tStore store)
        {

        }
        public virtual void Update(tStore store)
        {
        }
        public virtual void Delete(tStore storeId)
        {
        }
        public virtual void Save()
        {

        }
        public virtual IEnumerable<ApplicationUser> GetUsers() //List vs HashSet ?
        {
            return null;
        }
        public virtual ApplicationUser GetUser()
        {
            return null;
        }
        public virtual void CreateUser(ApplicationUser user, string password)
        {

        }
        public virtual void UpdateUser()
        {

        }
        public virtual void DeleteUser()
        {
        }
        public virtual List<ApplicationRole> GetRoles()
        {
            return null;
        }
        public virtual ApplicationRole GetRole()
        {
            return null;
        }
    }
}
