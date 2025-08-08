using Cadmium.Framework.Routing;
using Cadmium.Framework.Routing.Nodes;
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
                public FrameworkHandler()
                {
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

                        Router router = (Router)context.Application["Framework::Router"];
                        List<Tree> routeTrees = router.Routes;
                        Tree treeOfOrigin = routeTrees.FirstOrDefault(routeTree => routeTree.RootNode.Name == segments.FirstOrDefault());
                        INode traversed = treeOfOrigin?.RootNode;

                        foreach (var segment in segments)
                        {
                                var identified = traversed?.Children.FirstOrDefault(child => child.Name == segment);
                                if (identified == null) break;
                                traversed = identified;
                        }

                        if (traversed?.Condition.HasDefault ?? false)
                        {
                                var instance = PageParser.GetCompiledPageInstance($"{traversed?.RelativePath}/Default.aspx", null, context);
                                instance.ProcessRequest(context);
                        }

                        var errorPageInstance = PageParser.GetCompiledPageInstance("~/Routes/Error.aspx", null, context);
                        errorPageInstance.ProcessRequest(context);

                        //context.Response.ContentType = "application/json";
                        //context.Response.Write(
                        //        JsonSerializer.Serialize(
                        //                new { router.Routes }
                        //        )
                        //);
                }

                #endregion
        }
}
