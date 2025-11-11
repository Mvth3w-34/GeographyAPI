using GeographyAPI.Models;

namespace GeographyAPI.Repositories
{
    public class LanguageRepo : ILanguageRepo
    {

        public async Task<IEnumerable<Language>> GetAllLanguagesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Language> GetLanguageByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Language>> GetLanguagesByCountryAsync(string country)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Language>> GetLanguagesByFSIRankAsync(string rank)
        {
            throw new NotImplementedException();
        }
    }
}
