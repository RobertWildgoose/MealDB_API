using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMealDB.Services
{
	public class BaseService
	{
		public readonly string BaseUrl = "www.themealdb.com/api/json/v1/1/";
		public async Task<T> GetItem<T>(string url) where T : class
		{
			using (HttpClient client = new HttpClient())
			{
				try
				{
					var fullUrl = $"{BaseUrl}{url}";
					HttpResponseMessage response = await client.GetAsync(fullUrl);
					response.EnsureSuccessStatusCode();
					string json = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<T>(json ?? string.Empty);
				}
				catch (HttpRequestException ex)
				{
					Console.WriteLine($"Error: {ex.Message}");
					return null;
				}
			}
		}

		public async Task<List<T>> GetList<T>(string url) where T : class
		{
			using (HttpClient client = new HttpClient())
			{
				try
				{
					var fullUrl = $"{BaseUrl}{url}";
					HttpResponseMessage response = await client.GetAsync(fullUrl);
					response.EnsureSuccessStatusCode();
					string json = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<List<T>>(json ?? string.Empty);
				}
				catch (HttpRequestException ex)
				{
					Console.WriteLine($"Error: {ex.Message}");
					return null;
				}
			}
		}
	}
}
