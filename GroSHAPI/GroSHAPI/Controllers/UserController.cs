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
	public class UserController : ApiController
    {
		public IUserBusinessLayer _userBusinessLayer;
		public UserController(IUserBusinessLayer userBusinessLayer)
		{
			this._userBusinessLayer = userBusinessLayer;
		}

		[AllowAnonymous]
		[HttpPost]
		public HttpResponseMessage UserRegistration(UserDetails userDetails)
		{
			Response<int> response = new Response<int>();
			if (userDetails != null)
			{				
				var result = this._userBusinessLayer.UserRegistration(userDetails);
				if (result >= 1)
				{
					response.SatusCode = 200;
					response.Data = result;
					response.Message = Utility.Constants.SuccessMesg;
				}
				else if(result==-1)
				{
					response.SatusCode = 201;
					response.Data = result;
					response.Message = Utility.Constants.UserAlreadyExist;
				}
				else
				{
					response.SatusCode = 500;
					response.Data = result;
					response.Message = Utility.Constants.FailedMesg;
				}
			}
			return Request.CreateResponse(response);// Ok(response);
		}
	}
}
