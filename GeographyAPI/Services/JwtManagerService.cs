using GeographyAPI.Authentication;
using GeographyAPI.DTOs.Request;

namespace GeographyAPI.Services
{
    public class JwtManagerService : IJwtManagerService
    {
        private readonly IJwtGenerator _jwtGenerator;
        public JwtManagerService(IJwtGenerator jwtGenerator)
        {
            _jwtGenerator = jwtGenerator;
        }
        public string GenerateToken(TokenRequestDTO token)
        {
            return _jwtGenerator.CreateToken(token);
        }
    }
}
