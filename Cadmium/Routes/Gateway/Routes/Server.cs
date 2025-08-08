using Cadmium.Framework.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cadmium.Routes.Gateway.Routes
{
    [GatewayNode]
    public class Server
    {
        [HttpGet]
        public object GetRoutes(HttpContext context)
        {
            return new { context.User.Identity.IsAuthenticated };
        }
    }
}