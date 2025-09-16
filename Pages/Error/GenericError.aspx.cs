using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyTestApp.Pages.Error
{
    public partial class GenericError : System.Web.UI.Page
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        protected void Page_Load(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex != null)
            {
                logger.Error(ex, "Unhandled exception redirected to GenericError.aspx");
                Server.ClearError(); // Prevents endless redirect loops
            }
        }
    }
}