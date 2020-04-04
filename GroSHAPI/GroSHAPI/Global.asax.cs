using BusinessLayer;
using DataAccessLayer;
using GroSHAPI.App_Start;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace GroSHAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
			
            GlobalConfiguration.Configure(WebApiConfig.Register);
			var container = new Container();
			container.Register<IUserDataAccess, UserDataAccess>();
			container.Register<IUserBusinessLayer, UserBusinessLayer>();

			container.Register<IGrocSHItemDataAccess, GrocSHItemDataAccess>();
			container.Register<IGrocSHItemBusinessLayer, GrocSHItemBusinessLayer>();
			container.Verify();
			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
			GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorDependencyResolver(container);
		}
    }
}
