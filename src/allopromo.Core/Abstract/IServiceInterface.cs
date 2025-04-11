using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Services.Abstract
{
    // Service Contracts
    // Service Interface + Message Types = Service Layer//Business Logic + Validation Logi
    
    public interface IServiceInterface
    {

    }
    public interface IAuthenticateService
    {

    }
    public class AuthenticateService
    {

    }
}
    //public class ProductService
    //{

    /*
        public class Product
        {
            public string productName { get; set; }
            public string productDescription { get; set; }
            public int UnitsInStock { get; set; }
        }
        public bool CreateOrder(Product productToCreate)
        {
            if (!ValidateProduct(productToCreate))
                return false;
            else
            {
                try
                {

                }
                catch (Exception)
                {

                    throw;
                }
                return true;
            }
        }
        protected bool ValidateProduct(Product productToValidate)
        {
            /*
            if (productToValidate.productName.Trim().Length == 0)
                //_modelState.AddModelError("Name", "Name is required.");
            if (productToValidate.productDescription.Trim().Length == 0)
                //_modelState.AddModelError("Description", "Description is required.");
            if (productToValidate.UnitsInStock < 0)
                //_modelState.AddModelError("UnitsInStock", "Units in stock cannot be less than zero.");
            //return _modelState.IsValid;
            */

    /*
            return true;
        }

    */


    /*
    //}
    public interface IOrderService
    {

    }
    */
//}
