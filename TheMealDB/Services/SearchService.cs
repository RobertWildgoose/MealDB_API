using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMealDB.Interfaces;
using TheMealDB.Models;

namespace TheMealDB.Services
{
	public class SearchService : BaseService, ISearchService
	{
		public SearchService(IRequestHandler requestHandler) : base(requestHandler)
		{

		}

		public async Task<SearchMealResponse> SearchMealByName(string term)
		{
			if (!string.IsNullOrWhiteSpace(term))
			{
				var response = await GetItem<SearchMealResponse>($"search.php?s={term}");
				return response;
			}
			return null;
		}

		public async Task<SearchMealResponse> SearchMealByFirstLetter(string term)
		{
			if (!string.IsNullOrWhiteSpace(term) && term.Length == 1)
			{
				var response = await GetItem<SearchMealResponse>($"search.php?f={term}");
				return response;
			}
			return null;
		}

		public async Task<SearchMealResponse> SearchMealRandom()
		{
			var response = await GetItem<SearchMealResponse>($"random.php");
			return response;
		}
	}
}
