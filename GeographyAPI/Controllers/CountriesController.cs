using GeographyAPI.Models;
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
        public async Task<ActionResult<IEnumerable<Country>>> GetAllCountries()
        {
            IEnumerable<Country> countries = await _countryRepo.GetAllCountries();

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
        public async Task<ActionResult<Country>> GetCountriesByLanguage([FromQuery] string language)
        {
            IEnumerable<Country> countries = await _countryRepo.GetCountriesByLanguage(language);

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
        public async Task<ActionResult<Country>> GetCountryByID(int id)
        {
            Country country = await _countryRepo.GetCountryByID(id);

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
        public async Task<ActionResult<Country>> GetCountryByCapitalCity([FromQuery] string capital)
        {
            Country country = await _countryRepo.GetCountryByCapitalCity(capital);

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

