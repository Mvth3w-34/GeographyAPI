using GeographyAPI.DTOs.Request;

namespace GeographyAPI.Services
{
    public interface IJwtManagerService
    {
        public string GenerateToken(TokenRequestDTO token);
    }
}
