using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication1
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            this.Session["iduser"] = null;
            this.Session["login"] = null;
            this.Session["CartItemsCount"] = 0;
            this.Session["Error"] = "";
        }
        protected void Session_End(object sender, EventArgs e)
        {
            this.Session["CartItemsCount"] = 0;
        }
    }
}