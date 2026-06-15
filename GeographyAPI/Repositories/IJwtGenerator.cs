using GeographyAPI.DTOs.Request;

namespace GeographyAPI.Repositories
{
    public interface IJwtGenerator
    {
        string CreateToken(TokenRequestDTO request);
    }
}
