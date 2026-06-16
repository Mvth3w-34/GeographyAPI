using GeographyAPI.DTOs.External;
using GeographyAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Policy = "Language-readonly")]
        public async Task<ActionResult<IEnumerable<LanguageResponseDTO>>> GetAllLanguages()
        {
            IEnumerable<LanguageResponseDTO>? languages = await _languageRepo.GetAllLanguagesAsync();

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
        [Authorize(Policy = "Language-readonly")]
        public async Task<ActionResult<IEnumerable<LanguageResponseDTO>>> GetLanguagesByCountry([FromQuery] string country)
        {
            IEnumerable<LanguageResponseDTO>? languages = await _languageRepo.GetLanguagesByCountryAsync(country);

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
        [Authorize(Policy = "Language-readonly")]
        public async Task<ActionResult<IEnumerable<LanguageResponseDTO>>> GetLanguagesByFSI([FromQuery] string rank)
        {
            IEnumerable<LanguageResponseDTO>? languages = await _languageRepo.GetLanguagesByFSIRankAsync(rank);

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
        [Authorize(Policy = "Language-readonly")]
        public async Task<ActionResult<LanguageResponseDTO>> GetLanguageByID(int id)
        {
            LanguageResponseDTO? language = await _languageRepo.GetLanguageByIDAsync(id);

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
