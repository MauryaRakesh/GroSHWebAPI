using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
	public interface IUserDataAccess
	{
		UserInfo ValidateUser(string userName, string Password);
		int UserRegistration(UserDetails userDetail);
		int SendEmail(string email);
		int ResetPassword(string email, string newPassword);
	}
}
