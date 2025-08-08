using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Cadmium.Framework;

namespace Cadmium
{
        public class Global : HttpApplication
        {
                protected void Application_Start(object sender, EventArgs e)
                {
                        FrameworkApplication _frameworkApplication = new FrameworkApplication()
                        {
                                Context = HttpContext.Current,
                        };
                        _frameworkApplication.Initialise();
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

                }

                protected void Session_End(object sender, EventArgs e)
                {

                }

                protected void Application_End(object sender, EventArgs e)
                {

                }
        }
}