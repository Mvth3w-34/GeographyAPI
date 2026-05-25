using GeographyAPI.Models;

namespace GeographyAPI.Repositories
{
    public interface ILanguageRepo
    {
        Task<Language?> GetLanguageByIDAsync(int id);
        Task<IEnumerable<Language>?> GetAllLanguagesAsync();
        Task<IEnumerable<Language>?> GetLanguagesByCountryAsync(string country);

        Task<IEnumerable<Language>?> GetLanguagesByFSIRankAsync(string rank);
    }
}
