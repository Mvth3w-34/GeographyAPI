namespace GeographyAPI.DTOs.External
{
    public record ExternalLanguageDTO
    {
        public string Name { get; set; }

        public int HoursOfStudyForProficiency { get; set; }

        public string FSIRank { get; set; } //Ranges from 0 - V using Roman Numerals
    }
}