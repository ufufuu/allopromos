using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Core.Services
{
    public class MediaService:IMediaService
    {
        public HttpClient _httpClient { get; set; }//https://cdn.pixabay.com/photo/2013/10/15/09/12/flower-195893_150.jpg
        public string Url = "https://pixabay.com/api/?key=30135386-22f4f69d3b7c4b13c6e111db7&id=195893";
        public bool saveCategoryThumbnail()
        {
            return true;
        }
        public async Task<string> getImageInformationUrlAsync()
        {
            using(var httpClient = new HttpClient())
            {
                var imageInformationUlr = httpClient.BaseAddress=new Uri(Url);
                var httpResponseMsg = await httpClient.GetAsync(imageInformationUlr);

                var response = Newtonsoft.Json.JsonConvert.SerializeObject(httpResponseMsg);
                var image = (string)response;
                return image;
            }
        }
    }
}

