namespace GeographyAPI.Models
{
    public class CountryLanguage
    {
        public int Id { get; set; }

        public int CountryID { get; set; }

        public int LanguageID { get; set; }

        public Country Country { get; set; }

        public Language Language { get; set; }

    }
}
