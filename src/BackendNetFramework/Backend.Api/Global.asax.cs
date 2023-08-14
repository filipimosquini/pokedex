using Backend.Ioc.Configurations;
using System.Web.Http;

namespace Backend.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            GlobalConfiguration.Configuration.DependencyResolver = ContainerResolver.Resolve();
        }
    }
}
