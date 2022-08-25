using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using allopromo.Admin.Areas.Manage.Controllers;
using allopromo.Admin.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit;
using NUnit.Framework;
using System.Linq;
using Moq.Protected;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
namespace allopromo.Admin.UnitTests.UnitTests.Controllers
{
    [TestFixture]
    public class CategoriesControllerTests
    {
        Mock<HttpClient> _httpClientMock =
            new Mock<HttpClient>();
        private readonly Mock<HttpMessageHandler> _httpMsgHandlerMock =
            new Mock<HttpMessageHandler>();
        [Test]
        public void CategoriesController_CategoryName_Null_SHOULDThrowNull()
        {
            StoreCategoryDto categoryDto = null;
            var result = new CategoriesController().CreateStoreCategory(null);
            Assert.IsNull(result.Result);
        }
        [Test]
        public void CategoriesController_Create_SHOULDCreate_AndReturn_Store()
        {
            Mock<HttpMessageHandler> httpMsgHandlerMock = new Mock<HttpMessageHandler>();
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected();
            httpMsgHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                        "SendAsync",
                        ItExpr.IsAny<HttpRequestMessage>(),
                        ItExpr.IsAny<CancellationToken>()
                        )
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent("@{'categoryId':'1221','categoryName':'Super Marches'}") // Epiceries - Pharmacies - Beautes - buro
                });
            var httpClient = new HttpClient(handlerMock.Object); 
            var categoriesController = new CategoriesController();
            StoreCategoryDto categoryDto = new StoreCategoryDto()
            { 
                storeCategoryId=6897, 
                storeCategoryName="SuperMarchs", 
                categoryThumb="thumb",
                isParent=false
            };
            var categoryCreated = categoriesController.CreateStoreCategory("fdf"); //categoryDto);
            Assert.IsNotNull(categoryCreated);

            //httpMsgHandlerMock.Protected()
            //   .Verify(
            //           "SendAsync",
            //           Times.Exactly(1),
            //           ItExpr.IsAny<HttpRequestMessage>(),
            //           ItExpr.IsAny<CancellationToken>());
        }
        [Test]
        public async Task CategoriesController_List_SHOULD_ReturnStoreCategories()
        {
            HttpContent contentMessage = new StringContent("[{\"storeCategoryId\":1, \"storeCategoryName\":\"Boulangeries\"," +
                " \"isParent\":false, \"categoryThumb\":\"ffff\"}," +
                "{\"storeCategoryId\":1, \"storeCategoryName\":\"Boulangeries\", \"isParentj\":false, \"categoryThumb\":\"ffff\"}" +
                "]");
            var responseMessage = new HttpResponseMessage
            {
                StatusCode = new System.Net.HttpStatusCode(),
                Content = contentMessage
            };
            _httpMsgHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                ).ReturnsAsync(responseMessage);
            var contentString = contentMessage.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<StoreCategoryDto>>(contentString.Result);
            var categories = result as IEnumerable<StoreCategoryDto>;
            var httpClient = new HttpClient(_httpMsgHandlerMock.Object);
            var categoriesList = new CategoriesController(); // httpClient).List();
            Assert.IsNotNull(categoriesList);
            Assert.IsTrue(categories.Count().Equals(2));
        }
    }
}

/* 1- test - end to end categrie -
 * coorect methods 
 * 3. signalr ing 
 * 4 /
 */
