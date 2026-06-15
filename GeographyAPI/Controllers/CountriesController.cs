using GeographyAPI.DTOs.External;
using GeographyAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GeographyAPI.Controllers
{
    [Route("api/countries")]
    [ApiController]
    [Authorize]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepo _countryRepo;


        public CountriesController(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;

        }

        // GET: api/countries/all
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryResponseDTO>>> GetAllCountries()
        {
            IEnumerable<CountryResponseDTO>? countries = await _countryRepo.GetAllCountriesAsync();

            if (countries != null)
            {
                return Ok(countries);
            }
            else
            {
                return NotFound();
            }

        }

        // GET api/countries/
        [HttpGet("by-language")]
        public async Task<ActionResult<CountryResponseDTO>> GetCountriesByLanguage([FromQuery] string language)
        {
            IEnumerable<CountryResponseDTO>? countries = await _countryRepo.GetCountriesByLanguageAsync(language);

            if (countries != null)
            {
                return Ok(countries);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryResponseDTO>> GetCountryByID(int id)
        {
            CountryResponseDTO? country = await _countryRepo.GetCountryByIDAsync(id);

            if (country != null)
            {
                return Ok(country);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("by-capital")]
        public async Task<ActionResult<CountryResponseDTO>> GetCountryByCapitalCity([FromQuery] string capital)
        {
            CountryResponseDTO? country = await _countryRepo.GetCountryByCapitalCityAsync(capital);

            if (country != null)
            {
                return Ok(country);
            }
            else
            {
                return NotFound();
            }
        }
    }


}

