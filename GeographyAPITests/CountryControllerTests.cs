using GeographyAPI.Controllers;
using GeographyAPI.Models;
using GeographyAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace GeographyAPITests
{
    public class CountryControllerTests
    {
        private readonly ICountryRepo _countryMockRepo = Substitute.For<ICountryRepo>();



        [Fact]
        public async Task GetAllCountriesTestValidAsync()
        {

            //Assert

            var expectedItem = new List<Country> {
                new Country{CountryID = 1, Name = "Canada", Capital ="Ottawa" },
                new Country{CountryID = 2, Name = "USA", Capital = "WashingtonDC"},
                new Country{CountryID = 3, Name = "Mexico", Capital = "Mexico City"}, };

            _countryMockRepo.GetAllCountriesAsync().Returns(expectedItem);

            var controller = new CountriesController(_countryMockRepo);

            //Act

            var result = await controller.GetAllCountries();

            //Assert

            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;
            Assert.IsType<List<Country>>(list.Value);

            var listItems = list.Value as List<Country>;
            Assert.Equal(3, listItems.Count);

        }

        [Fact]
        public async Task GetAllCountriesTestInvalidAsync()
        {

            //Assert

            _countryMockRepo.GetAllCountriesAsync().ReturnsNull();

            var controller = new CountriesController(_countryMockRepo);

            //Act

            var result = await controller.GetAllCountries();

            //Assert

            Assert.IsType<NotFoundResult>(result.Result);
        }


        [Theory]
        [InlineData("English")]
        public async Task GetCountriesByLanguageTestValidAsync(string language)
        {

            //Assert

            var expectedItem = new List<Country> {
                new Country{CountryID = 1, Name = "Canada", Capital = "Ottawa"},
                new Country{CountryID = 2, Name = "USA", Capital = "WashingtonDC"}, };

            _countryMockRepo.GetCountriesByLanguageAsync(language).Returns(expectedItem);

            var controller = new CountriesController(_countryMockRepo);

            //Act

            var result = await controller.GetCountriesByLanguage(language);

            //Assert

            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;
            Assert.IsType<List<Country>>(list.Value);

            var listItems = list.Value as List<Country>;
            Assert.Equal(2, listItems.Count);

        }


        [Theory]
        [InlineData("English")]
        public async Task GetCountriesByLanguageTestInvalidAsync(string language)
        {
            //Assert

            _countryMockRepo.GetCountriesByLanguageAsync(language).ReturnsNull();

            var controller = new CountriesController(_countryMockRepo);

            //Act

            var result = await controller.GetCountriesByLanguage(language);

            //Assert

            Assert.IsType<NotFoundResult>(result.Result);

        }

        [Theory]
        [InlineData(1)]
        public async Task GetCountryByIDTestValidAsync(int id)
        {

            //Assert

            var expectedItem = new Country { CountryID = 1, Name = "Canada", Capital = "Ottawa" };

            _countryMockRepo.GetCountryByIDAsync(id).Returns(expectedItem);

            var controller = new CountriesController(_countryMockRepo);

            //Act

            var result = await controller.GetCountryByID(id);

            //Assert

            Assert.IsType<OkObjectResult>(result.Result);

            var item = result.Result as OkObjectResult;
            Assert.IsType<Country>(item.Value);

            var country = item.Value as Country;
            Assert.Equal("Canada", country.Name);

        }

        [Theory]
        [InlineData(1)]
        public async Task GetCountryByIDTestInvalidAsync(int id)
        {

            //Assert

            _countryMockRepo.GetCountryByIDAsync(id).ReturnsNull();

            var controller = new CountriesController(_countryMockRepo);

            //Act

            var result = await controller.GetCountryByID(id);

            //Assert

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Theory]
        [InlineData("Ottawa")]
        public async Task GetCountryByCapitalCityTestValidAsync(string capital)
        {

            //Assert

            var expectedItem = new Country { CountryID = 1, Name = "Canada", Capital = "Ottawa" };

            _countryMockRepo.GetCountryByCapitalCityAsync(capital).Returns(expectedItem);

            var controller = new CountriesController(_countryMockRepo);

            //Act

            var result = await controller.GetCountryByCapitalCity(capital);

            //Assert

            Assert.IsType<OkObjectResult>(result.Result);

            var item = result.Result as OkObjectResult;
            Assert.IsType<Country>(item.Value);

            var country = item.Value as Country;
            Assert.Equal("Canada", country.Name);

        }

        [Theory]
        [InlineData("Ottawa")]
        public async Task GetCountryByCapitalCityTestInvalidAsync(string capital)
        {

            //Assert

            _countryMockRepo.GetCountryByCapitalCityAsync(capital).ReturnsNull();

            var controller = new CountriesController(_countryMockRepo);

            //Act

            var result = await controller.GetCountryByCapitalCity(capital);

            //Assert

            Assert.IsType<NotFoundResult>(result.Result);
        }

    }
}
