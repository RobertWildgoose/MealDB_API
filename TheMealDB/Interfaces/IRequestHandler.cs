using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMealDB.Interfaces
{
	public interface IRequestHandler
	{
		public Task<string> GetAsync(string url);
	}
}
