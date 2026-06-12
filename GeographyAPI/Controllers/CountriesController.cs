using GeographyAPI.DTOs.External;
using GeographyAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GeographyAPI.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepo _countryRepo;


        public CountriesController(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;

        }

        // GET: api/countries/all
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExternalCountryDTO>>> GetAllCountries()
        {
            IEnumerable<ExternalCountryDTO>? countries = await _countryRepo.GetAllCountriesAsync();

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
        public async Task<ActionResult<ExternalCountryDTO>> GetCountriesByLanguage([FromQuery] string language)
        {
            IEnumerable<ExternalCountryDTO>? countries = await _countryRepo.GetCountriesByLanguageAsync(language);

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
        public async Task<ActionResult<ExternalCountryDTO>> GetCountryByID(int id)
        {
            ExternalCountryDTO? country = await _countryRepo.GetCountryByIDAsync(id);

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
        public async Task<ActionResult<ExternalCountryDTO>> GetCountryByCapitalCity([FromQuery] string capital)
        {
            ExternalCountryDTO? country = await _countryRepo.GetCountryByCapitalCityAsync(capital);

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

