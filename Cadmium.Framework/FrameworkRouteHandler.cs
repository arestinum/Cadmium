using Cadmium.Framework.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Cadmium
{
    public class FrameworkRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            FrameworkHandler frameworkHandler = new FrameworkHandler();

            return frameworkHandler;
        }
    }
}