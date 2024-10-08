using CountryApi.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    private readonly IcountryService _countryService;

    public CountryController(IcountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpPost("GetCountryByArea")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCountryByArea([FromBody] Areainfo areaInfo)
    {
        if (areaInfo == null || string.IsNullOrEmpty(areaInfo.Region) || string.IsNullOrEmpty(areaInfo.Timezones))
        {
            return BadRequest("Invalid area information.");
        }

        var result = await _countryService.GetCountriesByAreaAsync(areaInfo);
        return Ok(result);
    }
}
