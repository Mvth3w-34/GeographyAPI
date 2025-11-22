using GeographyAPI.Controllers;
using GeographyAPI.Models;
using GeographyAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace GeographyAPITests
{
    public class LanguageControllerTests
    {
        private readonly ILanguageRepo _languageMockRepo = Substitute.For<ILanguageRepo>();

        [Fact]
        public async Task GetAllLanguagesTestValidAsync()
        {

            //Assert
            var expectedItem = new List<Language> { new Language{ LanguageID=1, Name= "English", HoursOfStudyForProficiency = 0, FSIRank = "0"},
                new Language{ LanguageID=2, Name= "French", HoursOfStudyForProficiency = 675, FSIRank = "I"},
                new Language{ LanguageID=3, Name= "Spanish", HoursOfStudyForProficiency = 675, FSIRank = "I"}};

            _languageMockRepo.GetAllLanguagesAsync().Returns(expectedItem);

            var controller = new LanguagesController(_languageMockRepo);

            //Act
            var result = await controller.GetAllLanguages();


            //Assert

            //Check if it returns a 200 response
            Assert.IsType<OkObjectResult>(result.Result);

            //Check if the object is List<Language>
            var list = result.Result as OkObjectResult;
            Assert.IsType<List<Language>>(list.Value);

            //Check if the list contains the same number of items
            var listItems = list.Value as List<Language>;
            Assert.Equal(3, listItems.Count);


        }

        [Fact]
        public async Task GetAllLanguagesTestInvalid()
        {

            _languageMockRepo.GetAllLanguagesAsync().ReturnsNull();

            var controller = new LanguagesController(_languageMockRepo);


            var result = await controller.GetAllLanguages();


            Assert.IsType<NotFoundResult>(result.Result); //Check if it returns a 404 response

        }

        [Theory]
        [InlineData("Canada")]
        public async Task GetLanguagesByCountryValidAsync(string country)
        {
            //Assert
            var expectedItem = new List<Language> { new Language{ LanguageID=1, Name= "English", HoursOfStudyForProficiency = 0, FSIRank = "0"},
                new Language{ LanguageID=2, Name= "French", HoursOfStudyForProficiency = 675, FSIRank = "I"}, };


            _languageMockRepo.GetLanguagesByCountryAsync(country).Returns(expectedItem);

            var controller = new LanguagesController(_languageMockRepo);

            //Act
            var result = await controller.GetLanguagesByCountry(country);


            //Assert

            //Check if it returns a 200 response
            Assert.IsType<OkObjectResult>(result.Result);

            //Check if the object is List<Language>
            var list = result.Result as OkObjectResult;
            Assert.IsType<List<Language>>(list.Value);

            //Check if the list contains the same number of items
            var listItems = list.Value as List<Language>;
            Assert.Equal(2, listItems.Count);
        }

        [Theory]
        [InlineData("Canada")]
        public async Task GetLanguagesByCountryInvalidAsync(string country)
        {
            _languageMockRepo.GetLanguagesByCountryAsync(country).ReturnsNull();

            var controller = new LanguagesController(_languageMockRepo);


            var result = await controller.GetLanguagesByCountry(country);


            Assert.IsType<NotFoundResult>(result.Result); //Check if it returns a 404 response
        }

        [Theory]
        [InlineData("IV")]
        public async Task GetLanguagesByFSIValidAsync(string rank)
        {
            //Assert 
            var expectedItem = new List<Language> {
                new Language{ LanguageID=2, Name= "French", HoursOfStudyForProficiency = 675, FSIRank = "I"},
                new Language{ LanguageID=3, Name= "Spanish", HoursOfStudyForProficiency = 675, FSIRank = "I"} };

            _languageMockRepo.GetLanguagesByFSIRankAsync(rank).Returns(expectedItem);

            var controller = new LanguagesController(_languageMockRepo);

            //Action
            var result = await controller.GetLanguagesByFSI(rank);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;
            Assert.IsType<List<Language>>(list.Value);

            var listItems = list.Value as List<Language>;
            Assert.Equal(2, listItems.Count());
        }

        [Theory]
        [InlineData("IV")]
        public async Task GetLanguagesByFSIInvalid(string rank)
        {
            _languageMockRepo.GetLanguagesByFSIRankAsync(rank).ReturnsNull();

            var controller = new LanguagesController(_languageMockRepo);


            var result = await controller.GetLanguagesByFSI(rank);


            Assert.IsType<NotFoundResult>(result.Result);

        }

        [Theory]
        [InlineData(1)]
        public async Task GetLanguageByIDValidAsync(int id)
        {
            var expectedItem =
                new Language { LanguageID = 1, Name = "Spanish", HoursOfStudyForProficiency = 675, FSIRank = "I" };

            _languageMockRepo.GetLanguageByIDAsync(id).Returns(expectedItem);

            var controller = new LanguagesController(_languageMockRepo);

            //Action
            var result = await controller.GetLanguageByID(id);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var language = result.Result as OkObjectResult;
            Assert.IsType<Language>(language.Value);

        }

        [Theory]
        [InlineData(1)]
        public async Task GetLanguageByIDInvalidAsync(int id)
        {
            _languageMockRepo.GetLanguageByIDAsync(id).ReturnsNull();

            var controller = new LanguagesController(_languageMockRepo);


            var result = await controller.GetLanguageByID(id);


            Assert.IsType<NotFoundResult>(result.Result);

        }
    }
}
