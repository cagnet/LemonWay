using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace LemonWay
{
    public class Global : System.Web.HttpApplication
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start(object sender, EventArgs e)
        {
            var configFile = Directory.GetCurrentDirectory() + @"\log4net.config";
            XmlConfigurator.Configure(new FileInfo(configFile));

            //            log4net.Config.XmlConfigurator.Configure();
            //            BasicConfigurator.Configure();
            log.Info("Démarrage du service");

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Unhandled error occured in application. Sender: ");
            sb.AppendLine(Request.RawUrl);
            sb.Append("Query: ");
            sb.AppendLine(Request.QueryString.ToString());

            Exception ex = Server.GetLastError().GetBaseException();

            log.Error(sb.ToString(), ex);
            Server.ClearError();

            Response.Redirect("~/Error.aspx");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}