using Cadmium.Framework.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Routing;

namespace Cadmium.Framework
{
        public class FrameworkApplication
        {
                public FrameworkApplication() { }

                public HttpContext Context { get; set; }

                public HttpApplicationState Application
                {
                        get
                        {
                                return Context.Application;
                        }
                }

                public HttpServerUtility Server
                {
                        get
                        {
                                return Context.Server;
                        }
                }

                public void Initialise()
                {
                        Router router = new Router();
                        Application["Framework::Router"] = router;

                        RouteTable.Routes.Add("Application", new Route("{*route}", new FrameworkRouteHandler()));
                }
        }
}