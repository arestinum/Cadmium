using Cadmium.Framework.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Routing;

namespace Cadmium
{
    public class FrameworkApplication
    {
        public List<RouteTree> RouteTrees 
        { 
            get 
            { 
                return (List<RouteTree>)Application["Application::RouteTrees"]; 
            } 
        }
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
            List<RouteTree> routeTrees = new List<RouteTree>();
            string[] routes = Directory.GetDirectories(Server.MapPath("~/Routes"));
            foreach (string route in routes)
                routeTrees.Add(new RouteTree(route));

            Application["Application::RouteTrees"] = routeTrees;
            Application["Application::Startup"] = DateTime.Now;
            RouteTable.Routes.Clear();
        }
    }
}