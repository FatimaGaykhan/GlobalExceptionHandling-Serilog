using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Countries;
using Service.Services.Interfaces;

namespace WebApiArchitecture.Controllers.Admin
{
    public class CountryController : BaseController
    {

        private readonly ICountryService _countryService;
        private readonly ILogger<CountryController> _logger;

        public CountryController(ICountryService countryService,
                                ILogger<CountryController> logger)
        {
            _countryService = countryService;
            _logger = logger;
        }

        [HttpGet]
       public async Task<IActionResult> GetAll()
       {
            try
            {
                _logger.LogInformation("Country GetAll is working");
                return Ok(await _countryService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }

       }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CountryCreateDto request)
        {
            try
            {
                await _countryService.CreateAsync(request);
                return CreatedAtAction(nameof(Create), new { response = "Data succesfully created" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var result = await _countryService.GetByIdAsync((int)id);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {

                await _countryService.DeleteAsync((int)id);
                return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] CountryEditDto request)
        {
            await _countryService.EditAsync(request, (int)id);

            return Ok();

        }




    }
}

