using GeographyAPI.DTOs.Request;
using GeographyAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeographyAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IJwtManagerService _jwtManagerService;

        public AuthController(IJwtManagerService jwtManagerService)
        {
            _jwtManagerService = jwtManagerService;
        }

        [HttpPost]
        public ActionResult<string> CreateToken(TokenRequestDTO token)
        {
            if (ModelState.IsValid)
            {

                string jwtToken = _jwtManagerService.GenerateToken(token);

                return jwtToken;
            }

            return BadRequest();
        }

    }
}
