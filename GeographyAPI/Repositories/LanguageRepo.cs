using GeographyAPI.Data;
using GeographyAPI.DTOs.External;
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

        public async Task<IEnumerable<LanguageResponseDTO>?> GetAllLanguagesAsync()
        {
            return await _context.Language.Select(l => new LanguageResponseDTO
            {
                Name = l.Name,
                FSIRank = l.FSIRank
            }).ToListAsync();
        }

        public async Task<LanguageResponseDTO?> GetLanguageByIDAsync(int id)
        {
            LanguageResponseDTO? language = await _context.Language.Where(l => l.LanguageID == id)
                .Select(l => new LanguageResponseDTO
                {
                    Name = l.Name,
                    FSIRank = l.FSIRank
                })
                .FirstOrDefaultAsync();

            return language;
        }

        public async Task<IEnumerable<LanguageResponseDTO>?> GetLanguagesByCountryAsync(string country)
        {
            int? countryId = await _context.Country.Where(c => c.Name == country).Select(c => c.CountryID).FirstOrDefaultAsync();

            if (countryId == 0)
            {
                return null;
            }

            List<LanguageResponseDTO>? languages = await _context.CountryLanguage.Where(cl => cl.CountryID == countryId)
                .Select(cl => new LanguageResponseDTO
                {
                    Name = cl.Language.Name,
                    FSIRank = cl.Language.FSIRank
                })
                .ToListAsync();

            return languages;
        }

        public async Task<IEnumerable<LanguageResponseDTO>?> GetLanguagesByFSIRankAsync(string rank)
        {
            List<LanguageResponseDTO>? languages = await _context.Language.Where(l => l.FSIRank == rank).Select(l => new LanguageResponseDTO
            {
                Name = l.Name,
                FSIRank = l.FSIRank
            }).ToListAsync();

            return languages;
        }
    }
}
