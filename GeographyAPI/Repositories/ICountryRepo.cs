using GeographyAPI.Models;

namespace GeographyAPI.Repositories
{
    public interface ICountryRepo
    {
        Task<Country> GetCountryByIDAsync(int id);

        Task<IEnumerable<Country>> GetAllCountriesAsync();

        Task<Country> GetCountryByCapitalCityAsync(string name);

        Task<IEnumerable<Country>> GetCountriesByLanguageAsync(string language);

    }
}
