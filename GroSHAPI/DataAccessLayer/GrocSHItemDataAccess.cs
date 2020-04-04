using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;

namespace DataAccessLayer
{
	public class GrocSHItemDataAccess : IGrocSHItemDataAccess
	{
		public int AddGroSHItem(GrocSHItem grocShItem)
		{
			int flag = 0;
			try
			{
				using (GroSHDBEntities db = new GroSHDBEntities())
				{
					if (grocShItem.ItemId == 0)
					{
						db.GrocsharyItems.Add(new GrocsharyItem()
						{
							ItemName = grocShItem.ItemName,
							user_id = grocShItem.user_id,
							itemDescription = grocShItem.ItemDescription,
							exchangeItem = grocShItem.ExchangeItem,
							lat = grocShItem.Lat,
							lon = grocShItem.Lon,
							imageName = grocShItem.ImageName,
							createdDate = DateTime.Now,
							modifiedDate = DateTime.Now
						});
						flag = db.SaveChanges();

					}
					else
					{
						GrocsharyItem c = (from x in db.GrocsharyItems
										   where x.itemId == grocShItem.ItemId
										   select x).First();
						c.ItemName = grocShItem.ImageName;
						c.itemDescription = grocShItem.ItemDescription;
						c.exchangeItem = grocShItem.ExchangeItem;
						c.imageName = grocShItem.ImageName;
						flag = db.SaveChanges();
					}
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
			return flag;
		}
	}
}
