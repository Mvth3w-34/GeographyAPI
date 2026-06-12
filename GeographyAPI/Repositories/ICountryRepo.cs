using GeographyAPI.DTOs.External;

namespace GeographyAPI.Repositories
{
    public interface ICountryRepo
    {
        Task<CountryResponseDTO?> GetCountryByIDAsync(int id);

        Task<IEnumerable<CountryResponseDTO>?> GetAllCountriesAsync();
        Task<CountryResponseDTO?> GetCountryByCapitalCityAsync(string name);

        Task<IEnumerable<CountryResponseDTO>?> GetCountriesByLanguageAsync(string language);
    }
}
