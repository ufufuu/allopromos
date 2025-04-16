using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace allopromo.Core.Services
{
    public interface IMediaService
    {
        Task <IList<string>> SaveImages(ICollection<IFormFile> imageFiles);

        Task<string> SaveImage(IFormFile imageFile);
    }
}