//using Swagger.Net.Annotations;

namespace allopromo.Api.Controllers
{
    public class OrderStatus
    {   public enum orderStatus { Requested, Aknowledged, Started, Finished, Picked, Delivered };
    }
}
/*
 * https://www.c-sharpcorner.com/article/learn-about-web-api-validation/
 * 
 * Number of occurence in a Word , number of words in a Phrase !
 */
/* Asynchronous Method vs , whhen should I make a methdos Asynchronous ? What are Callbacks ?
 */
/* Fields vs Properties ??? */
/* Store Servcice having StoerRepo as Fields ? Why ?
 */
/*
 * //Singleton Pattern : Why Use ? //Extension Class  //Extensions Methods 0001-01-01 00:00:00.0000000 //Direct Casting vs Operator casting
 * 
 * */
/*
 * //[Authorize(AuthenticationSchemes = "Test")]
        //[Authorize(Roles = "users")]
*/
//[Authorize(AuthenticationSchemes = "Test")]//[BasicAuthenticationFilter]//[BasicJwtAuthorize] //vs [AuthorizeAttribute]?

//Delegates //Generic Delegates //Structs

//[Authorize(AuthenticationSchemes ="Test")] //[allopromo.Infrastructure.Providers.BasicAuthenticationFilter]
// ? Custom Authorization ?
//ActionExecutingContext actionContext)bwith [BasicJwt Attrib]!

//return Unauthorized();
//Secured Api Action

/* 4.. Shared kernel  Project ::::
 * Base Entity - Base value Object - Base Domain Events -Base specications - Common INterface
 * Common Exceptions - Comom Auth - Common Guards - Common Libraries , DI, Loggin, Validators
/****
 * 
 * Api Endpoint- Razor pages - Controllers - Views  - Api Models - ViewModels - Filters - Mmodel Binders -Tag Helpers
 * 
 * Interface rrurn types 
 *  COmpostion Root ?
 **
//Infrastructure Prject:
//Repositoriies - Api Clients ?  - DbContext Classes  - Cached Repositories  - File System Accessort - Azure Storeage
//Accessort - Emimailing Implement - SMS implementations - System Clock - Other Services , Interfaces 

///*github.com/ardalis/CleanArchitecture 
/*Ardalis Clean Archiecture Template from nuget 
/* CORE, What Beloing in the Core Project 
 * Interface
 * 
 * Aggregates (grouoing Entiites)
 * ValuesObjects( time , not Id contrary to Entities
 * 
 * Domain Services
 * 
 * Domain Exceptions 
 * Domain Events 
 * Evendt Handlers
 * 
 * Specification : library  ?
 * Validations : fluent Validation lib
 * Enurms
 * Custom Guards ? 
 */