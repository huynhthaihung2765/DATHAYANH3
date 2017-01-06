using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebDemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*botdetect}",
      new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });
            //    routes.MapRoute(
            //name: "Search",
            //url: "tim-kiem",
            //defaults: new { controller = "LinhKien", action = "Search", id = UrlParameter.Optional },
            //namespaces: new[] { "WebDemo.Controllers" }
            //);

            routes.MapRoute(
         name: "Google API Sign-in",
         url: "signin-google",
         defaults: new { controller = "Account", action = "ExternalLoginCallbackRedirect" }
     );





            routes.MapRoute(
       name: "Register",
       url: "dang-ky",
       defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional },
       namespaces: new[] { "WebDemo.Controllers" }
   );

            routes.MapRoute(
      name: "Login",
      url: "dang-nhap",
      defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
      namespaces: new[] { "WebDemo.Controllers" }
  );

            routes.MapRoute(
             name: "Warranty",
             url: "bao-hanh",
             defaults: new { controller = "LinhKien", action = "BaoHanh", id = UrlParameter.Optional },
             namespaces: new[] { "WebDemo.Controllers" }
         );
          

            routes.MapRoute(
            name: "Linh kien",
            url: "Linh-kien",
            defaults: new { controller = "LinhKien", action = "LinhKien", id = UrlParameter.Optional },
            namespaces: new[] { "WebDemo.Controllers" }
        );

            routes.MapRoute(
           name: "Product detail name",
           url: "Linh-kien/{metatitle}-{id}",
           defaults: new { controller = "LinhKien", action = "DetailsName", id = UrlParameter.Optional },
           namespaces: new[] { "WebDemo.Controllers" }
       );

            routes.MapRoute(
        name: "Payment",
        url: "thanh-toan",
        defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
        namespaces: new[] { "WebDemo.Controllers" }
    );



            routes.MapRoute(
            name: "Manage User",
            url: "tai-khoan",
            defaults: new { controller = "Manage", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "WebDemo.Controllers" }
        );

            routes.MapRoute(
          name: "Cart",
          url: "gio-hang",
          defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
          namespaces: new[] { "WebDemo.Controllers" }
      );

          
            routes.MapRoute(
         name: "Cart Null",
         url: "gio-hang-trong",
         defaults: new { controller = "Cart", action = "ThongBaoGioHangTrong", id = UrlParameter.Optional },
         namespaces: new[] { "WebDemo.Controllers" }
     );

            routes.MapRoute(
            name: "Add Cart",
            url: "them-gio-hang",
            defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
            namespaces: new[] { "WebDemo.Controllers" }
        );
            routes.MapRoute(
        name: "Product Detail",
        url: "Linh-Kien/",
        defaults: new { controller = "LinhKien", action = "Details", id = UrlParameter.Optional }

    );
            routes.MapRoute(
                    name: "Default",
                     url: "{controller}/{action}/{id}",
                     defaults: new { controller = "LinhKien", action = "Index", id = UrlParameter.Optional }
                  );
        }
    }
}
