using BusinessLayer;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace GroSHAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IUserBusinessLayer, UserBusinessLayer>();
			container.RegisterType<IGrocSHItemBusinessLayer, GrocSHItemBusinessLayer>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}