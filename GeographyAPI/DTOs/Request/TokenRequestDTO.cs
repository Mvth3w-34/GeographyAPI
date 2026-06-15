using System.ComponentModel.DataAnnotations;

namespace GeographyAPI.DTOs.Request
{
    public record TokenRequestDTO
    {
        [Required]
        public string ClientId { get; set; }

        [Required]
        public string Secret { get; set; }
    }
}
