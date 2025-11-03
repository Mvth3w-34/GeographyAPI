using GeographyAPI.Models;

namespace GeographyAPI.Repositories
{
    public class MockLanguageRepo : ILanguageRepo
    {
        public async Task<IEnumerable<Language>> GetAllLanguages()
        {
            return new List<Language> {
                new Language{ LanguageID=1, Name= "English", LevelOfDifficuly = 4, NumberOfSpeakers = 300},
                new Language{ LanguageID=2, Name= "French", LevelOfDifficuly = 3, NumberOfSpeakers = 400},
                new Language{ LanguageID=3, Name= "Spanish", LevelOfDifficuly = 5, NumberOfSpeakers = 500},
            };
        }

        public async Task<Language> GetLanguageByID(int id)
        {
            return new Language { LanguageID = 0, Name = "English", LevelOfDifficuly = 4, NumberOfSpeakers = 300 };
        }

        public async Task<IEnumerable<Language>> GetLanguagesByCountry(string country)
        {
            return new List<Language> {
                new Language{ LanguageID=1, Name= "English", LevelOfDifficuly = 4, NumberOfSpeakers = 300},
                new Language{ LanguageID=2, Name= "French", LevelOfDifficuly = 3, NumberOfSpeakers = 400},
                new Language{ LanguageID=3, Name= "Spanish", LevelOfDifficuly = 5, NumberOfSpeakers = 500},
            };
        }


    }
}
