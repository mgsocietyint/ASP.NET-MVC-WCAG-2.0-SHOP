using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Disabled
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Search",
                url: "sklep/wyszukaj",
                defaults: new { controller = "Shop", action = "Search" }
                );

            routes.MapRoute(
                name: "EditProduct",
                url: "zarządzanie/edycjaproduktu",
                defaults: new { controller = "Manage", action = "AddProduct" }
                );

            routes.MapRoute(
                name: "Manage",
                url: "zarządzanie",
                defaults: new { controller = "Manage", action = "Index" }
                );

            routes.MapRoute(
                name: "OrderConfirmation",
                url: "koszyk/podsumowanie/potwierdzenie",
                defaults: new { controller = "Cart", action = "OrderConfirmation" }
                );

            routes.MapRoute(
                name: "Checkout",
                url: "koszyk/podsumowanie",
                defaults: new { controller = "Cart", action = "Checkout" }
                );

            routes.MapRoute(
                name: "Cart",
                url: "koszyk",
                defaults: new { controller = "Cart", action = "Index" }
                );

            routes.MapRoute(
                name: "Login",
                url: "logowanie",
                defaults: new { controller = "Account", action = "Login" }
                );

            routes.MapRoute(
                name: "Register",
                url: "rejestracja",
                defaults: new { controller = "Account", action = "Register" }
                );

            routes.MapRoute(
                name: "ProductDetails",
                url: "sklep/{categoryname}/{id}",
                defaults: new { controller = "Shop", action = "ProductDetails" }
                );

            routes.MapRoute(
                name: "ProductsInCategory",
                url: "sklep/{categoryname}",
                defaults: new { controller = "Shop", action = "ProductList" }
                );

            routes.MapRoute(
                name: "Shop",
                url: "sklep",
                defaults: new { controller = "Shop", action = "Index" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
