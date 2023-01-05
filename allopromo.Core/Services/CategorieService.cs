using allopromo.Core.Abstract;
using allopromo.Core.Application.Dto;
using allopromo.Core.Entities;
using allopromo.Core.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace allopromo.Core.Services
{
    public class CategorieService: ICategorieService
    {
        private IRepository<tStoreCategory> _categorieRepository { get; set; }
        private IRepository<tDepartment> _departmentRepository { get; set; }
        public CategorieService(IRepository<tStoreCategory> categorieRepository,
             IRepository<tDepartment> departmentRepository)
        {
            _categorieRepository=categorieRepository;
            _departmentRepository = departmentRepository;
        }
        public CategorieService()
        {
        }
        public async Task<IEnumerable<StoreCategoryDto>> GetStoreCategoriesAsync()
        {
            IEnumerable<StoreCategoryDto> categories = null;
            try
            {
                IQueryable<tStoreCategory> query = _categorieRepository.GetAllAsync().Result.AsQueryable()

                //query//.Where(x => x.storeCategoryId.Equals(ID))
                    .Include(x => x.departmentId);
                var tCategories = query.AsEnumerable();
                categories = AutoMapper.Mapper.Map<IEnumerable<StoreCategoryDto>>(tCategories);

                if (categories != null)
                    return categories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public Entities.tStoreCategory GetCategoryById(string Id)
        {
            var category = new Entities.tStoreCategory {};
            return category;
        }
        #region StoresCategories
        public async Task<StoreCategoryDto> CreateStoreCategoryAsync(StoreCategoryDto category)
        {
            if (category == null)
                return null;
            var dateExpiring = DateTime.Now.AddMonths(6).Day.ToString("00");
            var storeCategoryDto = new StoreCategoryDto();
            var categoryObj = new tStoreCategory();

            categoryObj.storeCategoryName = category.storeCategoryName;
            categoryObj.storeCategoryId = Guid.NewGuid();
            categoryObj.active = true;

            var departmentDto = new DepartmentDto() { departmentName = "Alimentation" };
            var departments = AutoMapper.Mapper.Map<tDepartment>(departmentDto);
            var department = from q in await _departmentRepository.GetAllAsync()
                             //where  
                             select q;
            categoryObj.Department = department.FirstOrDefault();
            var imageUrl = string.Empty;
            if (PostCategoryImage() != null)
            {
                imageUrl = await this.GetImageUrl();
            }
            else
            {
                imageUrl = "http://www.noiamgesfornow.jpg";
            }
            await _categorieRepository.Add(categoryObj);//, imageUrl);
            return storeCategoryDto;
        }
        
        private async Task<tStoreCategory> GetDepartment(StoreCategoryDto categoryDto)
        {
            object department = null;
            //var _department = _departmentRepository.GetByIdAsync();
            department = await _categorieRepository.GetByIdAsync(categoryDto.storeCategoryId);

            return (tStoreCategory)department;
        }
        public void DeleteStoreCategory(string categoryId)
        {
        }
        public void UpdateStoreCategory(StoreCategoryDto category)
        {
            var obj = AutoMapper.Mapper.Map<tStoreCategory>(category);
            _categorieRepository.Update(obj);
        }
        public void UpdateStoreCategory(string Id, StoreCategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }
        public void DeleteStoreCategory(StoreCategoryDto storeCategoryDto)
        {
            if (storeCategoryDto == null)
            {
                var storeCategory = AutoMapper.Mapper.Map<tStoreCategory>(storeCategoryDto);
                //_storeRepository.DeleteStoreCategory(storeCategory);
                var category =_categorieRepository.GetByIdAsync("kjkjk");
                if (storeCategory == null)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    _categorieRepository.Delete(storeCategory);
                }
            }
        }
        public async Task<StoreCategoryDto> GetStoreCategoryAsyncById(string Id)
        {
            var categories = await this.GetStoreCategoriesAsync();
            var query = from q in categories
                        where q.storeCategoryId.ToString() == Id
                        select q;
            return query.FirstOrDefault();
        }
        #endregion StoresCategories
        private async Task<string> PostCategoryImage()
        {
            string response = string.Empty;
            var jsonObj = "{" +
                " \"data\": {" +
                " \"id\": \"soLHmGdX\", " +
                " \"url\": \"https://thumbsnap.com/soLHmGdX\", " +
                " \"media\": \"https://thumbsnap.com/i/soLHmGdX.png\", " +
                " \"thumb\": \"https://thumbsnap.com/t/soLHmGdX.jpg\", " +
                " \"width\": 224, " +
                " \"height\": 224 " +
                "}," +
                " \"success\": true, " +
                "  \"status\": 200 " +
            " }";
            string imageUrl = string.Empty;
            using (var httpClient = new HttpClient())
            {
                var Url = new Uri
                    ("https://thumbsnap.com/api/upload");
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, Url);
                var result = await httpClient.PostAsync("https://thumbsnap.com/api/upload", null);
                response = result.StatusCode.ToString();
                var obj = JsonConvert.DeserializeObject<ThumbyModel>(jsonObj);
                MediaApiResponseModel dataObj = obj.data;
                var image = JsonConvert.SerializeObject(dataObj);
                var media = JsonConvert.DeserializeObject<MediaApiResponseModel>(image);
                imageUrl = media.url;
            }
            return imageUrl;
        }
        public async Task<string> GetImageUrl()
        {
            MediaApiResponseModel data1 = new MediaApiResponseModel();
            string img = string.Empty;
            var response = await this.PostCategoryImage();
            if (response == null)
            {
                throw new Exception();
            }
            else
            {
                img = response;
            }
            return img;
        }
    }
}
