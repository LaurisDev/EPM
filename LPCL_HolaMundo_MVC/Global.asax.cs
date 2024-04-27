using LPCL_HolaMundo_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace LPCL_HolaMundo_MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error()
        {
            Exception ex = Server.GetLastError();

            if (ex != null)
            {
                if (ex is HttpException httpexception)
                {
                    string accion = (httpexception.GetHttpCode() == 404) ? "Error404" : "ErrorGeneral";
                    Context.ClearError();
                    RouteData rutaerror = new RouteData();
                    rutaerror.Values.Add("controller", "Error");
                    rutaerror.Values.Add("action", accion);
                    IController controlador = new ErrorController();
                    controlador.Execute(new RequestContext(new HttpContextWrapper(Context), rutaerror));
                }
                else
                {
                    // Manejar otras excepciones aquí
                    // Por ejemplo, registrar la excepción en un sistema de registro
                    // y redirigir a una página de error general.
                    Context.ClearError();
                    Response.Redirect("~/Error/Error404");
                }
            }
            else
            {
                // En caso de que la excepción sea nula, redirigir a una página de error general.
                Response.Redirect("~/Error/ErrorGeneral");
            }
        }

    }
}
