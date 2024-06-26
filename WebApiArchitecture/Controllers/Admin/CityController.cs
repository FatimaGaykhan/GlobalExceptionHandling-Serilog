using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Cities;
using Service.DTOs.Admin.Countries;
using Service.Services;
using Service.Services.Interfaces;

namespace WebApiArchitecture.Controllers.Admin
{
    public class CityController : BaseController
    {
        private readonly ICityService _cityService;
        private readonly ILogger<CityController> _logger;
        public CityController(ICityService cityService,
                             ILogger<CityController> logger)
        {
            _cityService = cityService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GetAll methhod is working");
            return Ok(await _cityService.GetAllAsync());

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CityCreateDto request)
        {

                await _cityService.CreateAsync(request);
                return CreatedAtAction(nameof(Create), new { response = "Data succesfully created" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _cityService.GetByIdAsync((int)id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var result = await _cityService.GetByName(name);
            return Ok(result);
        }

    }
}

