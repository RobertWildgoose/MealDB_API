using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMealDB.Interfaces;

namespace TheMealDB.Services
{
	public class BaseService
	{
		public readonly string BaseUrl = "www.themealdb.com/api/json/v1/1/";
		private readonly IRequestHandler _requestHandler;

        public BaseService(IRequestHandler requestHandler)
        {
			_requestHandler = requestHandler;
		}
        public async Task<T> GetItem<T>(string url) where T : class
		{
			try
			{
				string json = await _requestHandler.GetAsync($"{BaseUrl}{url}");
				return JsonConvert.DeserializeObject<T>(json ?? string.Empty);
			}
			catch(Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return null;
			}
		}

		public async Task<List<T>> GetList<T>(string url) where T : class
		{
			try
			{
				string json = await _requestHandler.GetAsync($"{BaseUrl}{url}");
				return JsonConvert.DeserializeObject<List<T>>(json ?? string.Empty);
			}
			catch(Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return null;
			}
		}
	}
}
