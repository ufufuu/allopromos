using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Interfaces
{
    public interface IImageUploadService
    {
        Task<string> SaveImages(ICollection<IFormFile> imageFiles);
        Task<string> SaveImage(IFormFile imageFile);
    }
}
