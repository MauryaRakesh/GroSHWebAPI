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
	//[Authorize]
	[AllowAnonymous]	
	public class UserController : ApiController
    {
		public IUserBusinessLayer _userBusinessLayer;
		public UserController(IUserBusinessLayer userBusinessLayer)
		{
			this._userBusinessLayer = userBusinessLayer;
		}

		//[AllowAnonymous]
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

		//[AllowAnonymous]
		[HttpPost]		
		public HttpResponseMessage SendEmail([FromUri] string email)
		{
			Response<int> response = new Response<int>();
			if (!string.IsNullOrEmpty(email))
			{
				var result = this._userBusinessLayer.SendEmail(email);
				if (result == 1)
				{
					response.SatusCode = 200;
					response.Data = result;
					response.Message = Utility.Constants.EmailExists;
				}
				else if (result == 2)
				{
					response.SatusCode = 201;
					response.Data = result;
					response.Message = Utility.Constants.EmailNotExist;
				}
				else
				{
					response.SatusCode = 500;
					response.Data = result;
					response.Message = Utility.Constants.FailedMesg;
				}
			}
			else
			{
				response.SatusCode = 500;
				response.Data = 1;
				response.Message = Utility.Constants.EmailBlank;
			}
			return Request.CreateResponse(response);// Ok(response);
		}

		//[AllowAnonymous]
		[HttpPost]		
		public HttpResponseMessage ResetPassword([FromUri] string email,string newPassword)
		{
			Response<int> response = new Response<int>();
			if (!string.IsNullOrEmpty(email)&& !string.IsNullOrEmpty(newPassword))
			{
				var result = this._userBusinessLayer.ResetPassword(email,newPassword);
				if (result == 1)
				{
					response.SatusCode = 200;
					response.Data = result;
					response.Message = Utility.Constants.PassReset;
				}
				else if (result == 2)
				{
					response.SatusCode = 201;
					response.Data = result;
					response.Message = Utility.Constants.EmailNotExist;
				}
				else
				{
					response.SatusCode = 500;
					response.Data = result;
					response.Message = Utility.Constants.FailedMesg;
				}
			}
			else
			{
				response.SatusCode = 500;
				response.Data = 1;
				response.Message ="Email and password can not  left blank";
			}
			return Request.CreateResponse(response);// Ok(response);
		}
	}
}
