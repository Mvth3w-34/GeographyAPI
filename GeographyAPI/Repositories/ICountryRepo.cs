using GeographyAPI.Models;

namespace GeographyAPI.Repositories
{
    public interface ICountryRepo
    {
        Task<Country> GetCountryByID(int id);

        Task<IEnumerable<Country>> GetAllCountries();

        Task<Country> GetCountryByCapitalCity(string name);

        Task<IEnumerable<Country>> GetCountriesByLanguage(string language);

    }
}
