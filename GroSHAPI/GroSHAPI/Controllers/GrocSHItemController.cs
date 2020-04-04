using BusinessLayer;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroSHAPI.Controllers
{
	[Authorize]
	public class GrocSHItemController : ApiController
    {
		
		public IGrocSHItemBusinessLayer _grocSHItemBusinessLayer;
		public GrocSHItemController(IGrocSHItemBusinessLayer grocSHItemBusinessLayer)
		{
			this._grocSHItemBusinessLayer = grocSHItemBusinessLayer;
		}

		[HttpPost]
		public HttpResponseMessage AddUpdateGroshItem(GrocSHItem grocSHItem)
		{
			Response<int> response = new Response<int>();
			if (grocSHItem != null)
			{
				var result = this._grocSHItemBusinessLayer.AddGroSHItem(grocSHItem);
				if (result == 1)
				{
					response.SatusCode = 200;
					response.Data = result;
					response.Message = grocSHItem.ItemId==0?Utility.Constants.SuccessMesg: Utility.Constants.UpdateMesg;
				}
				
				else
				{
					response.SatusCode = 201;
					response.Data = result;
					response.Message = Utility.Constants.FailedMesg;
				}
			}
			return Request.CreateResponse(response);// Ok(response);
		}
	}
}
