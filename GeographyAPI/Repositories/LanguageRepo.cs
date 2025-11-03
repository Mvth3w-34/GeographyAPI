using GeographyAPI.Models;

namespace GeographyAPI.Repositories
{
    public class LanguageRepo : ILanguageRepo
    {

        public async Task<IEnumerable<Language>> GetAllLanguages()
        {
            throw new NotImplementedException();
        }

        public async Task<Language> GetLanguageByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Language>> GetLanguagesByCountry(string country)
        {
            throw new NotImplementedException();
        }
    }
}
