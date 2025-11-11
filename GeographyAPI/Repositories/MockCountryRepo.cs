using GeographyAPI.Models;

namespace GeographyAPI.Repositories
{
    public class MockCountryRepo : ICountryRepo
    {
        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return new List<Country> {
                new Country{ CountryID = 1, Name = "Canada", Capital ="Ottawa" },
                new Country{CountryID = 2, Name = "USA", Capital = "WashingtonDC"},
                new Country{CountryID = 3, Name = "Mexico", Capital = "Mexico City"},
            };
        }

        public async Task<IEnumerable<Country>> GetCountriesByLanguage(string language)
        {
            return new List<Country> {
                new Country{CountryID = 1, Name = "Canada", Capital = "Ottawa"},
                new Country{CountryID = 2, Name = "USA", Capital = "WashingtonDC"},
            }; ;
        }

        public async Task<Country> GetCountryByCapitalCity(string name)
        {
            return new Country { CountryID = 1, Name = "Canada", Capital = "Ottawa" };
        }

        public async Task<Country> GetCountryByID(int id)
        {
            return new Country { CountryID = 1, Name = "Canada", Capital = "Ottawa" };
        }


    }
}
