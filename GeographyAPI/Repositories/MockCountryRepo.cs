using GeographyAPI.Models;

namespace GeographyAPI.Repositories
{
    public class MockCountryRepo : ICountryRepo
    {
        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            return new List<Country> {
                new Country{CountryID = 1, Name = "Canada", Capital ="Ottawa" },
                new Country{CountryID = 2, Name = "USA", Capital = "WashingtonDC"},
                new Country{CountryID = 3, Name = "Mexico", Capital = "Mexico City"},
            };
        }

        public async Task<IEnumerable<Country>> GetCountriesByLanguageAsync(string language)
        {
            return new List<Country> {
                new Country{CountryID = 1, Name = "Canada", Capital = "Ottawa"},
                new Country{CountryID = 2, Name = "USA", Capital = "WashingtonDC"},
            };
        }

        public async Task<Country> GetCountryByCapitalCityAsync(string name)
        {
            return new Country { CountryID = 1, Name = "Canada", Capital = "Ottawa" };
        }

        public async Task<Country> GetCountryByIDAsync(int id)
        {
            return new Country { CountryID = 1, Name = "Canada", Capital = "Ottawa" };
        }


    }
}
