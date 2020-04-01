using BusinessLayer;
using DataAccessLayer;
using DTO.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Cors;

namespace GroSHAPI.App_Start
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class ApplicationAuthProvider: OAuthAuthorizationServerProvider
	{
		public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			await Task.Delay(0);
			context.Validated();
		}
		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			await Task.Delay(0);
			UserDataAccess obj = new UserDataAccess();
			UserInfo user=obj.ValidateUser(context.UserName, context.Password);						
			if (user.IsValid)
			{
				var identity = new ClaimsIdentity( context.Options.AuthenticationType);
				identity.AddClaim(new Claim(Utility.Util.UserName, context.UserName));
				identity.AddClaim(new Claim(Utility.Util.Password, context.Password));
				var props = new AuthenticationProperties(new Dictionary<string, string>
				{
					{ Utility.Util.FirstName, user.FirstName },
					{ Utility.Util.LastName, user.LastName },
					{ Utility.Util.Email, user.Email },
					{ Utility.Util.Phone, user.Phone},
					{ Utility.Util.UserId, user.UserId }
				});
				var ticket = new AuthenticationTicket(identity, props);
				context.Validated(ticket);
			}
			else
			{
				context.SetError(Utility.Util.GrantType, Utility.Util.InvalidLogin);
				return;
			}
		}

		public override Task TokenEndpoint(OAuthTokenEndpointContext context)
		{
			foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
			{
				context.AdditionalResponseParameters.Add(property.Key, property.Value);
			}
			return Task.FromResult<object>(null);			
		}
	}
}