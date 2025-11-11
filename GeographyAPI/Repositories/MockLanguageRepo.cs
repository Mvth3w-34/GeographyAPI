using GeographyAPI.Models;

namespace GeographyAPI.Repositories
{
    public class MockLanguageRepo : ILanguageRepo
    {
        public async Task<IEnumerable<Language>> GetAllLanguagesAsync()
        {
            return new List<Language> {
                new Language{ LanguageID=1, Name= "English", HoursOfStudyForProficiency = 0, FSIRank = "0"},
                new Language{ LanguageID=2, Name= "French", HoursOfStudyForProficiency = 675, FSIRank = "I"},
                new Language{ LanguageID=3, Name= "Spanish", HoursOfStudyForProficiency = 675, FSIRank = "I"},
            };
        }

        public async Task<Language> GetLanguageByIDAsync(int id)
        {
            return new Language { LanguageID = 1, Name = "English", HoursOfStudyForProficiency = 0, FSIRank = "0" };
        }

        public async Task<IEnumerable<Language>> GetLanguagesByCountryAsync(string country)
        {
            return new List<Language> {
                new Language{ LanguageID=1, Name= "English", HoursOfStudyForProficiency = 0, FSIRank = "0"},
                new Language{ LanguageID=2, Name= "French", HoursOfStudyForProficiency = 675, FSIRank = "I"},
            };
        }

        public async Task<IEnumerable<Language>> GetLanguagesByFSIRankAsync(string rank)
        {
            return new List<Language> {
                new Language{ LanguageID=2, Name= "French", HoursOfStudyForProficiency = 675, FSIRank = "I"},
                new Language{ LanguageID=3, Name= "Spanish", HoursOfStudyForProficiency = 675, FSIRank = "I"},
            };
        }

    }
}
