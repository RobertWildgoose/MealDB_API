using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMealDB.Interfaces;
using TheMealDB.Services;

namespace TheMealDB
{
	public class MealDBClient
	{
		public MealDBClient() {
			var services = new ServiceCollection();
			services.AddSingleton<IRequestHandler,RequestHandler>();
			services.AddSingleton<ISearchService, SearchService>();
		}
	}
}
