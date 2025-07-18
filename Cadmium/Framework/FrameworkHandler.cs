using System;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Web;
using System.Web.Routing;
using System.Web.Services.Description;
using System.Web.UI;

namespace Cadmium
{
    public class FrameworkHandler : IHttpHandler
    {
        public RouteData RouteInformation { get; set; }
            
        public FrameworkHandler(RouteData routeData) {
            RouteInformation = routeData;
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

            var data = JsonSerializer.Serialize(new { context.Request.Url }, jsonSerializerOptions);
            context.Response.ContentType = "application/json"; 
            context.Response.Write(data);
        }

        #endregion
    }
}
