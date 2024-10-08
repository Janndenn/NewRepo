using CountryApi.Models;

namespace CountryApi.Services
{
    public interface CCountryService
    {
        Task<CountryByName> GetCountryByNameAsync(string countryName);
    }
}

