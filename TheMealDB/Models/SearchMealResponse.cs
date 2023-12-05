using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMealDB.Models
{
	public class SearchMealResponse
	{
		[JsonProperty(PropertyName = "meals")]
		public List<Meal> Meals { get; set; }
	}
}
