using allopromo.Admin;
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

        [Test]
        public async Task GetKjfkj()
        {
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {

                });
            var client = application.CreateClient();

        }
    }
    [TestFixture]
    public class ManageCategoryTest
    {
        private WebApplicationFactory<Startup> _factoryClient;
        public ManageCategoryTest(WebApplicationFactory<Startup> factoryClient)
        {
            _factoryClient = _factoryClient;
        }

        [Theory]
        [Test]
        [TestCase("fdf")]
        [TestCase("/Create")]
        public async Task GetHello()
        {
            //Arrange
            var client = _factoryClient.CreateClient();
            //Act
            var response = await  client.GetAsync("");
            //Assert
            Assert.IsNotNull(response);
            response.EnsureSuccessStatusCode();
            Assert.AreEqual("text/html, charset-utf8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
