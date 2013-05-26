using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RodeoDrive.WebUI.Infrastructure;
using RodeoDrive.Domain.Entities;
using RodeoDrive.WebUI.Binders;

namespace RodeoDrive.WebUI
{
    // Примечание: Инструкции по включению классического режима IIS6 или IIS7 
    // см. по ссылке http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "", new { controller = "Product", action = "List", category = (string)null, page = 1 });
            routes.MapRoute(null, "Page{page}", new { Controller = "Product", action = "List", category = (string)null }, new { page = @"\d+" });
            routes.MapRoute(null, "{category}", new { controller = "Product", action = "List", page = 1 });
            routes.MapRoute(null, // Имя маршрута
                "{category}/Page{page}", // URL-адрес с параметрами
                new { controller = "Product", action = "List" }, // Параметры по умолчанию
                new { page = @"\d+" }
            );
            routes.MapRoute(null, "{controller}/{action}");
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}