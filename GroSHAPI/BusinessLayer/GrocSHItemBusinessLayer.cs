using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using DataAccessLayer;

namespace BusinessLayer
{
	public class GrocSHItemBusinessLayer: IGrocSHItemBusinessLayer
	{
		private IGrocSHItemDataAccess _grocSHItemDataAccess;
		public GrocSHItemBusinessLayer(IGrocSHItemDataAccess grocSHItemDataAccess)
		{
			this._grocSHItemDataAccess = grocSHItemDataAccess;
		}

		public int AddGroSHItem(GrocSHItem grocShItem)
		{
			return this._grocSHItemDataAccess.AddGroSHItem(grocShItem);
		}
	}
}
