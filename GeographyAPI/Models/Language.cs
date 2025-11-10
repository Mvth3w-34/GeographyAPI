using System.ComponentModel.DataAnnotations;

namespace GeographyAPI.Models
{
    public class Language
    {
        [Key]
        public int LanguageID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int LevelOfDifficuly { get; set; }

        [Required]
        public int NumberOfSpeakers { get; set; }

        public List<CountryLanguage> CountryLanguage { get; set; }
    }
}
