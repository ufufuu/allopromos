using allopromo.Model.Validation;
using allopromo.Infrastructure.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.AspNetCore.Authorization;
namespace allopromo.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IConfiguration _config;
        public DefaultController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        //Testing ValidationException
        //[HttpResponseExceptionFilter]
        public IActionResult Get()
        {
            try
            {
                var defaultResult = "hello Default Controller this 02 May";
                return Ok(defaultResult);
            }
            catch(Exception ex)
            {
                throw;
            }
            /*
            try
            {
                int u = 5;
                
                var connectionString = _config.GetConnectionString("DefaultConnection");
                int y = 6;
                return connectionString.ToString();
                //return _dbContext.Database.CanConnect().ToString();
                //return _dbContext.Stores.AsAsyncEnumerable().ToString();
                int x = 5;
                if (x == 5)
                    throw new HttpResponseException("fhfhf");
            }
            catch(Exception ex)
            {
                throw ex;
            }*/
        }
    }
}
/*
 * 1.TransAction TABLES VS ENTIRY Tables 
 * 2.Instantiate Generic TYPES ?
 * 3.PCatalog  Class VS DishesMenu singled out food ?
 * 4. powershell init Azure DB !
 * */
/*
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

// ProductsCatalog Class -vs FoodMenu Class - > 
//composed of several products & catalog products !
//JWT Auth & Autho 
//1- install 5 nuget Packages - 2- settings config - 3-Setup Register & Login models & Response model Classes along with Roles
//4- 5- 