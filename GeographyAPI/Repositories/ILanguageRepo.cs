using GeographyAPI.DTOs.External;

namespace GeographyAPI.Repositories
{
    public interface ILanguageRepo
    {
        Task<ExternalLanguageDTO?> GetLanguageByIDAsync(int id);
        Task<IEnumerable<ExternalLanguageDTO>?> GetAllLanguagesAsync();
        Task<IEnumerable<ExternalLanguageDTO>?> GetLanguagesByCountryAsync(string country);

        Task<IEnumerable<ExternalLanguageDTO>?> GetLanguagesByFSIRankAsync(string rank);
    }
}
