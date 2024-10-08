public interface IcountryService
{
    Task<IEnumerable<countryinfo>> GetCountriesByAreaAsync(Areainfo areaInfo);
}
