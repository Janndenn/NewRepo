using CountryApi.Services;
using System.Net.Http.Json;
using System.Text.Json;


public class AcountryService : IcountryService
{
    private readonly HttpClient _httpClient;

    public AcountryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<countryinfo>> GetCountriesByAreaAsync(Areainfo areaInfo)
    {
        // Use the latest API endpoint
        var allCountries = await _httpClient.GetFromJsonAsync<List<apicountryinfo>>("https://restcountries.com/v3.1/all");

        if (allCountries == null)
        {
            throw new Exception("Unable to fetch country data.");
        }

        // Filter countries by Region and Timezone
        return allCountries
            .Where(country => country.Region.Equals(areaInfo.Region, StringComparison.OrdinalIgnoreCase) &&
                              country.Timezones != null &&
                              country.Timezones.Contains(areaInfo.Timezones))
            .Select(country => new countryinfo
            {
                Name = country.Name.Common,
                Alpha2Code = country.Cca2,
                Capital = country.Capital != null && country.Capital.Any() ? country.Capital.First() : "N/A",
                CallingCodes = country.Idd != null ? new List<string> { country.Idd.Root + country.Idd.Suffixes.FirstOrDefault() } : new List<string>(),
                FlagUrl = country.Flags != null ? country.Flags.Png : "N/A",
                Timezones = country.Timezones
            });
    }
}

