using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;

namespace BusinessLayer
{
	public class UserBusinessLayer : IUserBusinessLayer
	{
		private IUserDataAccess _userDataAccessLayer;
		public UserBusinessLayer(IUserDataAccess userAccessDataLayer)
		{
			this._userDataAccessLayer = userAccessDataLayer;
		}

		

		public int UserRegistration(UserDetails userDetail)
		{
			return this._userDataAccessLayer.UserRegistration(userDetail);
		}

		public int SendEmail(string email)
		{
			return this._userDataAccessLayer.SendEmail(email);
		}

		public int ResetPassword(string email, string newPassword)
		{
			return this._userDataAccessLayer.ResetPassword(email,newPassword);
		}
	}
}
