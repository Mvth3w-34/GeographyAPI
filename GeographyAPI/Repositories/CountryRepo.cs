using GeographyAPI.Models;

namespace GeographyAPI.Repositories
{
    public class CountryRepo : ICountryRepo
    {


        public async Task<Country> GetCountryByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            throw new NotImplementedException();
        }

        public async Task<Country> GetCountryByCapitalCity(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Country>> GetCountriesByLanguage(string language)
        {
            throw new NotImplementedException();
        }
    }
}
