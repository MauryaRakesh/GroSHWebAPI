using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
	public class UserDataAccess : IUserDataAccess
	{
		
		/// <summary>
		/// Implement validate user interface
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public UserInfo ValidateUser(string userName, string password)
		{
			UserInfo userInfo = new UserInfo();
			GroSHDBEntities db = new GroSHDBEntities();
			try
			{
				var user = db.UsersInfoes.FirstOrDefault(m => (m.email == userName) && (m.password == password));
				if (user != null)
				{
					userInfo.FirstName = user.first_Name;
					userInfo.LastName = user.last_Name;
					userInfo.Email = user.email;
					userInfo.Phone = user.phone;
					userInfo.UserId = Convert.ToString(user.id);
					userInfo.IsValid = true;
				}
				else
				{
					userInfo.IsValid = false;
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}

			return userInfo;
		}

		/// <summary>
		/// User Registration interface implementation
		/// </summary>
		/// <param name="userDetail"></param>
		/// <returns></returns>
		public int UserRegistration(UserDetails userDetail)
		{
			int flag = 0;
			using (GroSHDBEntities db = new GroSHDBEntities())
			{
				db.UsersInfoes.Add(new UsersInfo()
				{
					first_Name = userDetail.FirstName,
					last_Name = userDetail.LastName,
					email = userDetail.Email,
					phone = userDetail.Phone,
					password = userDetail.Password,
					createdDate = DateTime.Now.ToUniversalTime()
				});
				flag = db.SaveChanges();
				if (flag == 1)
				{
					var user = db.UsersInfoes.FirstOrDefault(m => (m.email == userDetail.Email) && (m.phone == userDetail.Phone));
					if (user != null)
					{
						db.UsersAddresses.Add(new UsersAddress()
						{
							addressLine = userDetail.AddressLine,
							city = userDetail.City,
							state = userDetail.State,
							country = userDetail.Country,
							user_id =user.id,
							createdDate=DateTime.Now.ToUniversalTime()
						});
						db.SaveChanges();
					}
				}
			}
			return flag;
		}

	}
}
