
using allopromo.Api.DTOs;
using allopromo.Core.Abstract;
using allopromo.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace allopromo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces("application/json", new string[] { })]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly
#nullable disable
    IConfiguration _config;
        private readonly ILocalisationService _localisationService;
        private IMapper _mapper;

        public CitiesController(
          IConfiguration config,
          IMapper mapper,
          ILocalisationService localizeService)
        {
            this._config = config;
            this._localisationService = localizeService;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCities()
        {
            CitiesController citiesController = this;
            IEnumerable<City> cities = await citiesController._localisationService.GetCities();
            return cities == null ? (IActionResult)citiesController.BadRequest() : (IActionResult)citiesController.Ok((object)cities);
        }

        [HttpGet]
        [Route("cities+{cityId}")]
        public IActionResult GetCityById(string cityId)
        {
            try
            {
                return (IActionResult)this.Ok((object)this._localisationService.GetCities());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult PostCity([FromBody] CityDto cityDto)
        {
            try
            {
                bool result = this._localisationService.CreateAsync(this._mapper.Map<City>((object)cityDto)).Result;
                return (IActionResult)this.Ok((object)cityDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("cities+{cityId}")]
        public async Task<IActionResult> Delete(string Id)
        {
            CitiesController citiesController = this;
            IActionResult actionResult;
            try
            {
                (await citiesController._localisationService.GetCities()).Select<City, City>((Func<City, City>)(c => c));
                actionResult = (IActionResult)citiesController.Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actionResult;
        }

        [HttpGet]
        [Route("city")]
        public IActionResult getCurrentCity(string currentIp)
        {
            currentIp = "41.207.160.90";
            return (IActionResult)this.Ok((object)this._localisationService.GetUserCurrentCity(currentIp));
        }
    }
}
