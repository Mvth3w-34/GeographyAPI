using System.ComponentModel.DataAnnotations;

namespace GeographyAPI.Models
{
    public class Language
    {
        [Key]
        public int LanguageID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public int HoursOfStudyForProficiency { get; set; }

        [Required]
        [StringLength(3)]
        public string FSIRank { get; set; } //Ranges from 0 - V using Roman Numerals
        public List<CountryLanguage> CountryLanguage { get; set; }
    }
}
