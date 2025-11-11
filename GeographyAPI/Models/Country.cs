using System.ComponentModel.DataAnnotations;

namespace GeographyAPI.Models
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(16)]
        public string Capital { get; set; }

        [StringLength(300)]
        public string? TriviaFact { get; set; }

        public List<CountryLanguage> CountryLanguage { get; set; }

    }
}
