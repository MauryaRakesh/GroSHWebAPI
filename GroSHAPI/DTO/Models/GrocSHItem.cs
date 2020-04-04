using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
 public	class GrocSHItem
	{
		public int ItemId { get; set; } = 0;
		public int user_id { get; set; }
		public string ItemName { get; set; }
		public string ItemDescription { get; set; }
		public string ExchangeItem { get; set; }
		public string Lat { get; set; }
		public string Lon { get; set; }
		public string ImageName { get; set; }
	}
}
