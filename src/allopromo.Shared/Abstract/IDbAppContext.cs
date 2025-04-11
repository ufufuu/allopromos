using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Shared.Abstract
{
    public interface IDbAppContext
    {
        //public void DeleteAsync(string Id);
        //public void SaveChangesAsync();
        //public void FindAsync();
    }
}



/*
 * In case, I Do not Wannt to Use Generic Reposiory and forget all about Repository,
 * since EF itself is some sort of Repo
 * Create this IAppDbContext interfce here so all the rest of the 
 * App would have access to it as part of DI
 * Abstrat the DbContext by creating an interface of it. Include all DbSets and all
 * repo methods we want to access to ( SaveChangesAsync, FindAsync, ect..)
 * Thid interface resides in Domain Layer where as the implementation resides in Infra
 * on one of the outers layers of the onion)
 *
 */
