using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace MyTestApp
{
    public class Global : HttpApplication
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        void Application_Start(object sender, EventArgs e)
        {
            logger.Info("Application started");

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            var authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null) return;

            try
            {
                var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                var roles = (ticket.UserData ?? "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                var identity = new GenericIdentity(ticket.Name);
                var principal = new GenericPrincipal(identity, roles);
                Context.User = principal;
            }
            catch
            {
                // ignore decryption errors, treat as anonymous
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            logger.Error(ex, "Unhandled error occurred");

            // Redirect to error page
            Server.ClearError();
            Response.Redirect("~/Pages/Error/GenericError.aspx");
        }
    }
}