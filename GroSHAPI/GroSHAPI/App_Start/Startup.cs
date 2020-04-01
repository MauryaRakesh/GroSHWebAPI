using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(GroSHAPI.App_Start.Startup))]

namespace GroSHAPI.App_Start
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
			app.UseCors(CorsOptions.AllowAll);
			OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
			{

				TokenEndpointPath = new PathString("/api/Login"),
				Provider = new ApplicationAuthProvider(),
				AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
				AllowInsecureHttp = true
			};
			app.UseOAuthAuthorizationServer(option);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
		}
	}
}
