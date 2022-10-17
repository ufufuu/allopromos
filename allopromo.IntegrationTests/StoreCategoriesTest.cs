using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.IntegrationTests
{
    [TestFixture]
    public class StoreCategoriesTest
    {
        //private WebApplicationFactory<Startup> clientFactory { get; set; } // ClientOptions client = new Web
        public StoreCategoriesTest()
        {
            //var application = new WebApplicationFactory<Program>()
            //    .WithWebHostBuilder(builder =>
            //    {
            //    });
            //var clientFactory = application.CreateClient();
        }
        
        public void  GetHello() //asyn Task
        {
            ////var client = clientFactory.CreateClient();
            //var response = await client.GetAsync("api/v1/categories/");
            //Assert.IsNotNull(response);
            //response.EnsureSuccessStatusCode();
            //Assert.AreEqual("text/html, charset-utf8",
            //    response.Content.Headers.ContentType.ToString());
        }
    }
}







//Integration Testing :
//DB
//File System
//Network resource 