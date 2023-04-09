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
        private readonly ILocalisationService _localisationService;
        private static Serilog.ILogger logger; 

        //private readonly IExceptionWriter _exceptionWriter;
        public CitiesController(IConfiguration config,
                           ILocalisationService localizeService)
                           //IExceptionWriter exceptionWriter)
        {
            _config = config;
            _localisationService = localizeService;
            //_exceptionWriter = exceptionWriter;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _localisationService.GetCities();
            if (cities != null)
                return Ok(cities);
            return BadRequest();
        }
        [HttpGet]
        [Route("cities+{cityId}")]
        public IActionResult GetCityById(string cityId)
        {
            try
            {
                var city = _localisationService.GetCities();
                return Ok(city);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        //[Route(ConstancesCommunes)]
        public IActionResult PostCity([FromBody] CityDto city)
        {
            try
            {
                var tci = _localisationService.CreateAsync(city).Result;
                return Ok(city);
            }
            catch (Exception ex)
            {
                //_exceptionWriter.WriteException(ex.ToString());
                throw;
            }
            return NotFound();
        }
        
        [HttpDelete]
        [Route("cities+{cityId}")]
        public async Task<IActionResult> Delete(string Id)
        {
            try
            {
                var city = from c in (await _localisationService.GetCities()) 
                           select c;
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("city")]
        public IActionResult getCurrentCity(string currentIp)
        {
            //currentIp = "74.57.247.6";
            currentIp = "41.207.160.90";
            var city = _localisationService.GetUserCurrentCity(currentIp);
            return Ok(city);
        }
    }
}
