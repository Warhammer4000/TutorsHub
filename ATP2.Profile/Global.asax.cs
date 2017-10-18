
using System;
using System.Web.Mvc;
using System.Web.Routing;
using Entity;


namespace ATP2.Profile
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
        }
    }
}
