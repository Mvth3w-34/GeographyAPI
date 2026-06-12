using GeographyAPI.Data;
using GeographyAPI.DTOs.External;
using Microsoft.EntityFrameworkCore;

namespace GeographyAPI.Repositories
{
    public class CountryRepo : ICountryRepo
    {
        private readonly GeographyContext _context;

        public CountryRepo(GeographyContext context)
        {
            _context = context;
        }


        public async Task<CountryResponseDTO?> GetCountryByIDAsync(int id)
        {
            CountryResponseDTO? country = await _context.Country.Where(c => c.CountryID == id)
                .Select(c => new CountryResponseDTO
                {
                    Name = c.Name,
                    Capital = c.Capital,
                    TriviaFact = c.TriviaFact
                })
                .FirstOrDefaultAsync();

            return country;
        }

        public async Task<IEnumerable<CountryResponseDTO>?> GetAllCountriesAsync()
        {
            List<CountryResponseDTO>? countries = await _context.Country
                .Select(c => new CountryResponseDTO
                {
                    Name = c.Name,
                    Capital = c.Capital,
                    TriviaFact = c.TriviaFact
                })
                .ToListAsync();

            return countries;
        }

        public async Task<CountryResponseDTO?> GetCountryByCapitalCityAsync(string name)
        {
            CountryResponseDTO? country = await _context.Country.Where(c => c.Capital == name)
                .Select(c => new CountryResponseDTO
                {
                    Name = c.Name,
                    Capital = c.Capital,
                    TriviaFact = c.TriviaFact
                })
                .FirstOrDefaultAsync();

            return country;
        }

        public async Task<IEnumerable<CountryResponseDTO>?> GetCountriesByLanguageAsync(string language)
        {
            int? languageId = await _context.Language.Where(l => l.Name == language).Select(l => l.LanguageID).FirstOrDefaultAsync();

            if (languageId == 0)
            {
                return null;
            }

            List<CountryResponseDTO>? countries = await _context.CountryLanguage.Where(cl => cl.LanguageID == languageId)
                .Select(cl => new CountryResponseDTO
                {
                    Name = cl.Country.Name,
                    Capital = cl.Country.Capital,
                    TriviaFact = cl.Country.TriviaFact
                })
                .ToListAsync();

            return countries;
        }
    }
}
