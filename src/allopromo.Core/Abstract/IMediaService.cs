using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace allopromo.Core.Services
{
    public interface IMediaService
    {
        Task<string> SaveProductImages(ICollection<IFormFile> imageFiles);

        Task<string> SaveProductImage(IFormFile imageFile);
    }
}