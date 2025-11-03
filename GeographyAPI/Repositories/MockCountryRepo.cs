using GeographyAPI.Models;

namespace GeographyAPI.Repositories
{
    public class MockCountryRepo : ICountryRepo
    {
        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return new List<Country> {
                new Country{ CountryID = 1, Name = "Canada", Capital ="Ottawa", Population= 2000, Independence = new DateTime(1867,6,1) },
                new Country{ CountryID = 2, Name = "USA", Capital ="WashingtonDC", Population= 3000, Independence = new DateTime(1867,6,4) },
                new Country{ CountryID = 3, Name = "Mexico", Capital ="Mexico City", Population= 4000, Independence = new DateTime(1821,8,24) },
            };
        }

        public async Task<IEnumerable<Country>> GetCountriesByLanguage(string language)
        {
            return new List<Country> {
                new Country{ CountryID = 1, Name = "Canada", Capital ="Ottawa", Population= 2000, Independence = new DateTime(1867,6,1) },
                new Country{ CountryID = 2, Name = "USA", Capital ="WashingtonDC", Population= 3000, Independence = new DateTime(1867,6,4) },
            }; ;
        }

        public async Task<Country> GetCountryByCapitalCity(string name)
        {
            return new Country { CountryID = 1, Name = "Canada", Capital = "Ottawa", Population = 2000, Independence = new DateTime(1867, 6, 1) };
        }

        public async Task<Country> GetCountryByID(int id)
        {
            return new Country { CountryID = 1, Name = "Canada", Capital = "Ottawa", Population = 2000, Independence = new DateTime(1867, 6, 1) };
        }


    }
}
