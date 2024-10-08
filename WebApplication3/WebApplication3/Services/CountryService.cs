using System.Text.Json;
using CountryApi.Models;
using CountryApi.Services;

public class CountryService : CCountryService
{
    private readonly HttpClient _httpClient;

    public CountryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CountryByName> GetCountryByNameAsync(string countryName)
    {
        var response = await _httpClient.GetAsync($"https://restcountries.com/v2/name/{countryName}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var countryData = JsonSerializer.Deserialize<List<CountryByName>>(content, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        return countryData?.FirstOrDefault();
    }
}

