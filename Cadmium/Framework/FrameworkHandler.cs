using Cadmium.Framework.Routing;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Web;
using System.Web.UI;

namespace Cadmium
{
    public class FrameworkHandler : IHttpHandler
    {
        public FrameworkHandler() {
        }

        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
            { 
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var segments = context.Request.Url.Segments
                .Select(segment => segment.Trim('/'))
                .Where(segment => !string.IsNullOrEmpty(segment))
                .ToList();

            if (segments.Count() == 0) segments.Add("/");

            List<RouteTree> routeTrees = (List<RouteTree>)context.Application["Application::RouteTrees"];
            RouteTree treeOfOrigin = routeTrees.FirstOrDefault(routeTree => routeTree.Root.Name == segments.FirstOrDefault());
            RouteNode traversed = treeOfOrigin.Root;

            foreach (var segment in segments)
            {
                var identified = traversed.Children.FirstOrDefault(child => child.Name == segment);
                if (identified == null) break;
                traversed = identified;
            }

            if (context.Request["view"] == "application::namespace")
            {
                var assembly = Assembly.GetAssembly(GetType());
                var data = JsonSerializer.Serialize(
                    assembly.ExportedTypes
                        .Where(type => type.Namespace.StartsWith("Cadmium.Routes.Gateway"))
                        .Select(type => new { type.Namespace, type.Name }), 
                    jsonSerializerOptions
                );
                context.Response.ContentType = "application/json";
                context.Response.Write(data);
                return;
            }

            if (context.Request["view"] == "application::internal")
            { 
                var data = JsonSerializer.Serialize(new { segments, traversed, treeOfOrigin, routeTrees }, jsonSerializerOptions);
                context.Response.ContentType = "application/json"; 
                context.Response.Write(data);
                return;
            }

            if (traversed.Condition.HasDefault)
            {
                var instance = PageParser.GetCompiledPageInstance($"{traversed.RelativePath}/Default.aspx", null, context);
                instance.ProcessRequest(context);
            }
        }

        #endregion
    }
}
