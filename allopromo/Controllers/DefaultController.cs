using allopromoDataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Controllers
{
    // ProductsCatalog Class -vs FoodMenu Class - > composed of several products & catalog products !
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public DefaultController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public string  Get()
        {
            try
            {
               var provider = _dbContext;

                int u = 5;
                return provider.Database.CanConnect().ToString();
                //return provider.Stores.Count().ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            //finally
            //{
                //provider = "Not for Now";
            //}
        }
    }
}
/*
 * 
 * 
 * 1.TransAction TABLES VS ENTIRY Tables 
 * 2.Instantiate Generic TYPES ?
 * 3.PCatalog  Class VS DishesMenu singled out food ?
 * 4. powershell init Azure DB !
 * 
 * */
/*
 * 
 * 
 * Instanciate Generic Type ??
                return Ok(provider.Database.CanConnect());
Server=tcp:enov.database.windows.net,1433;Initial Catalog=allopromo;Persist Security Info=False;
User ID=aliwiyao;
Password=K@da120790;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
 */

/*
 * UBER CLONE } Sonny Sangha
 * Reacy Native \ using Expo | setting the dev environnement , install expo globally: -g expo-cli
 * react
 * redux
 * TailwindCSS
 * REact native elements
 * React navigation
 * React native maps
 * google 
 *  rn google-places-autocomplete
 *  
 *  
 *  Builder Design Pattern ex:
 *  public class User:IUser
 *      p rea Name, 
 *      p readon 
 *      
 */

//Coiffeur  : 418-261-1266-

/*
 * add-migration -Name "defaultConn", v1
 * update-database -Connection "defuoo"
 */