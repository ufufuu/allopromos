using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Services.Media
{
    public class ImGurMediaService : IMediaService
    {
        private const
#nullable disable
    string URL = "http://api.imgur/com/3";
        private const string CLIENT_ID = "9b56b331436f6b4";
        private const string CLIENT_SECRET = "8a17cfb28060c0202ba7cff9b5172cd0a56f26fa";
        private const string pin = "";

        public HttpClient _httpClient { get; set; }

        public async Task<string> SaveProductImages(ICollection<IFormFile> imagesFiles)
        {
            ImgurClient imgurClient = new ImgurClient("9b56b331436f6b4", "8a17cfb28060c0202ba7cff9b5172cd0a56f26fa");
            HttpClient httpClient = new HttpClient();
            using (IEnumerator<IFormFile> enumerator = imagesFiles.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    IFormFile current = enumerator.Current;
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.Headers.Add("Authorization", "CLIENT_ID9b56b331436f6b4");
                        return Encoding.ASCII.GetString(webClient.UploadValues("http://api/imgur.com/3/image/", "POST", new NameValueCollection()
                        {
                            ["image"] = "base64",
                            ["type"] = "base64"
                        }));
                    }
                }
            }
            return (string)null;
        }

        public async Task<string> getImageInformationUrlAsync()
        {
            string informationUrlAsync;
            using (HttpClient httpClient = new HttpClient())
                informationUrlAsync = JsonConvert.SerializeObject((object)await httpClient.GetAsync(httpClient.BaseAddress = new Uri("http://api.imgur/com/3")));
            return informationUrlAsync;
        }

        public async Task<string> SaveProductImage(IFormFile fileName)
        {
            if (fileName == null)
                throw new NullReferenceException(nameof(fileName));
            MultipartFormDataContent content = new MultipartFormDataContent();
            string str;
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.PostAsync("bee.com", (HttpContent)content))
                    str = await response.Content.ReadAsStringAsync();
            }
            return str;
        }

        private async Task<bool> ValidateImageFilesSize(string files)
        {
            bool flag;
            return flag;
        }
    }
}
