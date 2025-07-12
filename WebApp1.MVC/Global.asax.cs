using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApp1.MVC.App_Start;

namespace WebApp1.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DIConfig.RegisterDependencies();
        }
    }
}
