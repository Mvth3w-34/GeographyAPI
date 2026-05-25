using GeographyAPI.Data;
using GeographyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GeographyAPI.Repositories
{
    public class LanguageRepo : ILanguageRepo
    {
        private readonly GeographyContext _context;

        public LanguageRepo(GeographyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Language>?> GetAllLanguagesAsync()
        {
            return await _context.Language.ToListAsync();
        }

        public async Task<Language?> GetLanguageByIDAsync(int id)
        {
            Language? language = await _context.Language.Where(l => l.LanguageID == id).FirstOrDefaultAsync();

            return language;
        }

        public async Task<IEnumerable<Language>?> GetLanguagesByCountryAsync(string country)
        {
            int? countryId = await _context.Country.Where(c => c.Name == country).Select(c => c.CountryID).FirstOrDefaultAsync();

            if (countryId == 0)
            {
                return null;
            }

            List<Language>? languages = await _context.CountryLanguage.Where(cl => cl.CountryID == countryId)
                .Select(cl => cl.Language)
                .ToListAsync();

            return languages;
        }

        public async Task<IEnumerable<Language>?> GetLanguagesByFSIRankAsync(string rank)
        {
            List<Language>? languages = await _context.Language.Where(l => l.FSIRank == rank).ToListAsync();

            return languages;
        }
    }
}
