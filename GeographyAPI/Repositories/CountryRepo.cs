using GeographyAPI.Data;
using GeographyAPI.Models;
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


        public async Task<Country> GetCountryByIDAsync(int id)
        {
            Country? country = await _context.Country.Where(c => c.CountryID == id).FirstOrDefaultAsync();

            return country;
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            List<Country> countries = await _context.Country.ToListAsync();

            return countries;
        }

        public async Task<Country> GetCountryByCapitalCityAsync(string name)
        {
            Country? country = await _context.Country.Where(c => c.Capital == name).FirstOrDefaultAsync();

            return country;
        }

        public async Task<IEnumerable<Country>> GetCountriesByLanguageAsync(string language)
        {
            int? languageId = await _context.Language.Where(l => l.Name == language).Select(l => l.LanguageID).FirstOrDefaultAsync();

            if (languageId == 0)
            {
                return null;
            }

            List<Country>? countries = await _context.CountryLanguage.Where(cl => cl.LanguageID == languageId)
                .Select(cl => cl.Country)
                .ToListAsync();

            return countries;
        }
    }
}
