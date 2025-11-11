using GeographyAPI.Models;

namespace GeographyAPI.Repositories
{
    public class CountryRepo : ICountryRepo
    {


        public async Task<Country> GetCountryByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Country> GetCountryByCapitalCityAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Country>> GetCountriesByLanguageAsync(string language)
        {
            throw new NotImplementedException();
        }
    }
}
