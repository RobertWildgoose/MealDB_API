using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMealDB.Models;

namespace TheMealDB.Interfaces
{
	public interface ISearchService
	{
		public Task<SearchMealResponse> SearchMealByName(string term);
		public Task<SearchMealResponse> SearchMealByFirstLetter(string term);
		public Task<SearchMealResponse> SearchMealRandom();
	}
}
