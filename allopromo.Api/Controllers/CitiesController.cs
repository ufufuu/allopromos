using allopromo.Model.Validation;
using allopromo.Infrastructure.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.AspNetCore.Authorization;
using allopromo.Core.Contracts;
using allopromo.Core.Abstract;
using allopromo.Core.Exceptions;
using allopromo.Core.Application.Dto;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CitiesController : ControllerBase
       // ApiController
    {
        private readonly IConfiguration _config;
        private readonly ILocalizeService _localizeService;

        private readonly IExceptionWriter _exceptionWriter;
        public CitiesController(IConfiguration config,
                           ILocalizeService localizeService)
                           //IExceptionWriter exceptionWriter)
        {
            _config = config;
            _localizeService = localizeService;

            //_exceptionWriter = exceptionWriter;
        }

        [HttpPost]
        //[Route(ConstancesCommunes)]
        public IActionResult PostCity([FromRoute] CityDto city)
        {
            try
            {
                _localizeService.Create(city);
            }
            catch (Exception ex)
            {
                //_exceptionWriter.WriteException(ex.ToString());
                throw;
            }
            return Ok(city);
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _localizeService.GetCities();
            if (cities!= null)
                return Ok(cities);
            return BadRequest();
        }
        [HttpGet]
        [Route("cities+{cityId}")]
        public IActionResult GetCityById(string cityId)
        {
            try
            {
                var city = _localizeService.GetCities();
                return Ok(city);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        [Route("cities+{cityId}")]
        public async Task<IActionResult> Delete(string Id)
        {
            try
            {
                var city = from c in await _localizeService.GetCities()
                           where c.cityId.Equals(Id)
                           select c;
                //_localizeService.Delete(city.FirstOrDefault());
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
