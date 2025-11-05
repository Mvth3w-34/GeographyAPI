using GeographyAPI.Models;
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

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Language>>> GetAllLanguages()
        {
            IEnumerable<Language> languages = await _languageRepo.GetAllLanguages();

            if (languages != null)
            {
                return Ok(languages);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("by-country")]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguagesByCountry([FromQuery] string country)
        {
            IEnumerable<Language> languages = await _languageRepo.GetLanguagesByCountry(country);
            if (languages != null)
            {
                return Ok(languages);
            }
            else
            {
                return BadRequest();
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetLanguageByID(int id)
        {
            Language language = await _languageRepo.GetLanguageByID(id);

            if (language != null)
            {
                return Ok(language);
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
