using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation.Mvc;
using Organization.CastleWindsor;
using Castle.Windsor;

namespace Orgainzation.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FluentValidationModelValidatorProvider.Configure(); 
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MapperConfig.RegisterMappings();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var container = new WindsorContainer()
              .Install(new AdminInstaller());
        }
    }
}
