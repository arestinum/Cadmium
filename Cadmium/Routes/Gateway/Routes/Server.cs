using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cadmium.Routes.Gateway.Routes
{
    public class Server
    {
        public object GetRoutes(HttpContext context)
        {
            return new { context.User.Identity.IsAuthenticated };
        }
    }
}