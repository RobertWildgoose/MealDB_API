using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TheMealDB.Interfaces;
using TheMealDB.Services;
using TheMealDB_Tests.Common;

namespace TheMealDB_Tests.Services
{
	public class SearchService_Tests : BaseTest<SearchService>
	{
		private SearchService SubjectUnderTest;
		private Mock<IRequestHandler> RequestHandlerMock;
		[SetUp]
		public void SetUp()
		{
			RequestHandlerMock = new Mock<IRequestHandler>();
			RequestHandlerMock.Setup(a => a.GetAsync("www.themealdb.com/api/json/v1/1/search.php?s=ValidData")).ReturnsAsync(TestData.SearchMealResponse.ValidData);
			RequestHandlerMock.Setup(a => a.GetAsync("www.themealdb.com/api/json/v1/1/search.php?s=EmptyData")).ReturnsAsync(TestData.SearchMealResponse.EmptyData);
			RequestHandlerMock.Setup(a => a.GetAsync("www.themealdb.com/api/json/v1/1/search.php?s=Empty")).ReturnsAsync(TestData.SearchMealResponse.Empty);

			RequestHandlerMock.Setup(a => a.GetAsync("www.themealdb.com/api/json/v1/1/search.php?f=A")).ReturnsAsync(TestData.SearchMealResponse.ValidData);
			RequestHandlerMock.Setup(a => a.GetAsync("www.themealdb.com/api/json/v1/1/search.php?f=B")).ReturnsAsync(TestData.SearchMealResponse.EmptyData);
			RequestHandlerMock.Setup(a => a.GetAsync("www.themealdb.com/api/json/v1/1/search.php?f=C")).ReturnsAsync(TestData.SearchMealResponse.Empty);
			SubjectUnderTest = new SearchService(RequestHandlerMock.Object);
		}
		//Search Meal By Name
		[TestCase(null)]
		[TestCase("")]
		[TestCase(" ")]
		public async Task SearchMealByName_WhenTextIsInvalid_ShouldReturnNull(string searchTerm)
		{
			var response = await SubjectUnderTest.SearchMealByName(searchTerm);
			Assert.That(response, Is.Null);
		}

		[TestCase("ValidData")]
		public async Task SearchMealByName_WhenTextIsValid_ReturnsValidData_ShouldReturnValidData(string searchTerm)
		{
			var response = await SubjectUnderTest.SearchMealByName(searchTerm);
			Assert.AreEqual(response.Meals.Count(), 2);
		}

		[TestCase("EmptyData")]
		public async Task SearchMealByName_WhenTextIsValid_ReturnsEmptySearchData_ShouldReturnEmptyData(string searchTerm)
		{
			var response = await SubjectUnderTest.SearchMealByName(searchTerm);
			Assert.AreEqual(response.Meals.Count(), 0);
		}

		[TestCase("Empty")]
		public async Task SearchMealByName_WhenTextIsValid_ReturnsEmpty_ShouldReturnNull(string searchTerm)
		{
			var response = await SubjectUnderTest.SearchMealByName(searchTerm);
			Assert.AreEqual(response.Meals, null);
		}

		//Search Meal By First Letter
		[TestCase(null)]
		[TestCase("")]
		[TestCase(" ")]
		[TestCase("bb")]
		public async Task SearchMealByFirstLetter_WhenTextIsInvalid_ShouldReturnNull(string searchTerm)
		{
			var response = await SubjectUnderTest.SearchMealByFirstLetter(searchTerm);
			Assert.That(response, Is.Null);
		}

		[TestCase("A")]
		public async Task SearchMealByFirstLetter_WhenTextIsValid_ReturnsValidData_ShouldReturnValidData(string searchTerm)
		{
			var response = await SubjectUnderTest.SearchMealByFirstLetter(searchTerm);
			Assert.AreEqual(response.Meals.Count(), 2);
		}

		[TestCase("B")]
		public async Task SearchMealByFirstLetter_WhenTextIsValid_ReturnsEmptySearchData_ShouldReturnEmptyData(string searchTerm)
		{
			var response = await SubjectUnderTest.SearchMealByFirstLetter(searchTerm);
			Assert.AreEqual(response.Meals.Count(), 0);
		}

		[TestCase("C")]
		public async Task SearchMealByFirstLetter_WhenTextIsValid_ReturnsEmpty_ShouldReturnNull(string searchTerm)
		{
			var response = await SubjectUnderTest.SearchMealByFirstLetter(searchTerm);
			Assert.AreEqual(response.Meals, null);
		}
	}
}
