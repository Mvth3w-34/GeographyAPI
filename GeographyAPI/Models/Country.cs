using System.ComponentModel.DataAnnotations;

namespace GeographyAPI.Models
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Capital { get; set; }

        [Required]
        public int Population { get; set; }

        [Required]
        public DateTime Independence { get; set; }

        public string? TriviaFact { get; set; }

        ICollection<Language> Languages { get; set; }

    }
}
