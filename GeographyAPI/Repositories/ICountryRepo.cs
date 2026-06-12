using GeographyAPI.DTOs.External;

namespace GeographyAPI.Repositories
{
    public interface ICountryRepo
    {
        Task<ExternalCountryDTO?> GetCountryByIDAsync(int id);

        Task<IEnumerable<ExternalCountryDTO>?> GetAllCountriesAsync();
        Task<ExternalCountryDTO?> GetCountryByCapitalCityAsync(string name);

        Task<IEnumerable<ExternalCountryDTO>?> GetCountriesByLanguageAsync(string language);
    }
}
