using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMealDB.Interfaces;

namespace TheMealDB.Services
{
	public class RequestHandler : IRequestHandler
	{
		public async Task<string> GetAsync(string url)
		{
			HttpResponseMessage response;
			using (HttpClient client = new HttpClient())
			{
				try
				{
					response = await client.GetAsync(url);
				}
				catch (HttpRequestException ex)
				{
					Console.WriteLine($"Error: {ex.Message}");
					return null;
				}
			}
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsStringAsync();
		}
	}
}
