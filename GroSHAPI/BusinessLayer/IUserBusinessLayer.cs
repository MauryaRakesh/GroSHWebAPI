using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public interface IUserBusinessLayer
	{
		int UserRegistration(UserDetails userDetail);
		int SendEmail(string email);
		int ResetPassword(string email, string newPassword);
	}
}
