using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TiendaMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //de ruta mas especifica a ruta generica

            routes.MapRoute(
                name: "ProductoDetalle",
                url: "item/{nombre}",
                defaults: new
                {
                    controller="Producto",
                    action = "Detalle",
                    nombre = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Producto", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
