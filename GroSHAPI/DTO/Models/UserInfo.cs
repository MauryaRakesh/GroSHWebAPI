using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
	public class UserInfo
	{
		public string UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public bool IsValid { get; set; }
	}

	public class UserDetails
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Password { get; set; }
		public string AddressLine { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public string Zipcode { get; set; }
		public string Lat { get; set; }
		public string Lon { get; set; }
	}
}
