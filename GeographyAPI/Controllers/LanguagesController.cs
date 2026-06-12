using GeographyAPI.DTOs.External;
using GeographyAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GeographyAPI.Controllers
{
    [Route("api/languages")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageRepo _languageRepo;
        public LanguagesController(ILanguageRepo languageRepo)
        {
            _languageRepo = languageRepo;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExternalLanguageDTO>>> GetAllLanguages()
        {
            IEnumerable<ExternalLanguageDTO>? languages = await _languageRepo.GetAllLanguagesAsync();

            if (languages != null)
            {
                return Ok(languages);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("by-country")]
        public async Task<ActionResult<IEnumerable<ExternalLanguageDTO>>> GetLanguagesByCountry([FromQuery] string country)
        {
            IEnumerable<ExternalLanguageDTO>? languages = await _languageRepo.GetLanguagesByCountryAsync(country);

            if (languages != null)
            {
                return Ok(languages);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("by-FSIRank")]
        public async Task<ActionResult<IEnumerable<ExternalLanguageDTO>>> GetLanguagesByFSI([FromQuery] string rank)
        {
            IEnumerable<ExternalLanguageDTO>? languages = await _languageRepo.GetLanguagesByFSIRankAsync(rank);

            if (languages != null)
            {
                return Ok(languages);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExternalLanguageDTO>> GetLanguageByID(int id)
        {
            ExternalLanguageDTO? language = await _languageRepo.GetLanguageByIDAsync(id);

            if (language != null)
            {
                return Ok(language);
            }
            else
            {
                return NotFound();
            }
        }


    }
}
