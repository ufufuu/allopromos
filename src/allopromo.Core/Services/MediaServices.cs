using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace allopromo.Core.Services
{

    public class ImageUploadMediaService : IMediaService
    {
        private const string client_Id = "9b56b331436f6b4";
        private const string client_Secret = "8a17cfb28060c0202ba7cff9b5172cd0a56f26fa";
        private const string pin = "";
        public const string imgGurUrl = "https://api.imgur.com/";
        public const string imgGurUrl2 = "https://imgur-apiv3.p.rapidapi.com/";
        public const string imgUrlGur = "https://api.imgur.com/oauth2/token";

        private static HttpClient getHttpClient() => new HttpClient();

        public async Task<string> SaveProductImage(IFormFile imageFile)
        {
            HttpClient httpClient = new HttpClient();
            return "http://api.imggur.com/3/xfepppe.jpg";
        }

        public async Task<string> SaveProductImages(ICollection<IFormFile> imageFiles)
        {
            if (imageFiles != null)
            {
                IEnumerator<IFormFile> enumerator = imageFiles.GetEnumerator();
                string str;
                try
                {
                    IFormFile current;
                    do
                    {
                        if (enumerator.MoveNext())
                            current = enumerator.Current;
                        else
                            goto label_14;
                    }
                    while (current.Length <= 0L);
                    using (File.Create(Path.GetTempFileName()))
                    {
                        str = await this.SaveProductImage(current);
                        goto label_16;
                    }
                }
                finally
                {
                    enumerator?.Dispose();
                }
            label_14:
                enumerator = (IEnumerator<IFormFile>)null;
                goto label_15;
            label_16:
                return str;
            }
        label_15:
            throw new NullReferenceException("Image files");
        }

        public async Task<string> CreateAttachmentAsync(string fileName)
        {
            HttpClient httpClient = ImageUploadMediaService.getHttpClient();
            MultipartFormDataContent content = new MultipartFormDataContent()
      {
        {
          (HttpContent) new StreamContent((Stream) new FileStream(fileName, FileMode.Open)),
          "files[]"
        }
      };
            string attachmentAsync;
            using (HttpResponseMessage response = await httpClient.PostAsync("https://xxx.supportbee.com/attachments?auth_token=xxx", (HttpContent)content))
                attachmentAsync = await response.Content.ReadAsStringAsync();
            return attachmentAsync;
        }
    }
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

