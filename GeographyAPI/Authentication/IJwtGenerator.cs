using GeographyAPI.DTOs.Request;

namespace GeographyAPI.Authentication
{
    public interface IJwtGenerator
    {
        string CreateToken(TokenRequestDTO request);
    }
}
