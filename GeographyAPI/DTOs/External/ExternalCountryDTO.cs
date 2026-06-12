namespace GeographyAPI.DTOs.External
{
    public record ExternalCountryDTO
    {

        public string Name { get; set; }
        public string Capital { get; set; }
        public double? TriviaFact { get; set; }
    }
}