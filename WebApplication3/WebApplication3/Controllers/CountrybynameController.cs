using CountryApi.Models;
using CountryApi.Services;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Controllers;

namespace CountryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CountrybynameController : ControllerBase
    {
        private readonly CCountryService _countryService;

        public CountrybynameController(CCountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost("GetCountryByName")]
        public async Task<IActionResult> GetCountryByName([FromBody] string countryByName)
        {
            if (string.IsNullOrEmpty(countryByName))
            {
                return BadRequest("Country name is required.");
            }

            var countryInfo = await _countryService.GetCountryByNameAsync(countryByName);

            if (countryInfo == null)
            {
                return NotFound("Country not found.");
            }

            return Ok(countryInfo);
        }
    }
}

