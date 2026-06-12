namespace GeographyAPI.DTOs.External
{
    public record LanguageResponseDTO
    {
        public string Name { get; set; }

        public int HoursOfStudyForProficiency { get; set; }

        public string FSIRank { get; set; } //Ranges from 0 - V using Roman Numerals
    }
}