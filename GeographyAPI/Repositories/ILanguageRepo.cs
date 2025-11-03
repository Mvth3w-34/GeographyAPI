using GeographyAPI.Models;

namespace GeographyAPI.Repositories
{
    public interface ILanguageRepo
    {
        Task<Language> GetLanguageByID(int id);
        Task<IEnumerable<Language>> GetAllLanguages();
        Task<IEnumerable<Language>> GetLanguagesByCountry(string country);

    }
}
