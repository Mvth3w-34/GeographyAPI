using GeographyAPI.DTOs.External;

namespace GeographyAPI.Repositories
{
    public interface ILanguageRepo
    {
        Task<LanguageResponseDTO?> GetLanguageByIDAsync(int id);
        Task<IEnumerable<LanguageResponseDTO>?> GetAllLanguagesAsync();
        Task<IEnumerable<LanguageResponseDTO>?> GetLanguagesByCountryAsync(string country);

        Task<IEnumerable<LanguageResponseDTO>?> GetLanguagesByFSIRankAsync(string rank);
    }
}
