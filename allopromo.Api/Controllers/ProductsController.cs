﻿using allopromo.Core.Application.Dto;
using allopromo.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController() 
        {
        }
        [HttpGet]
        public List<StoreDto> GetProducts()
        {
            return new List<StoreDto>();
        }
    }
}