using System.Web;

namespace Cadmium.Framework
{
        public class CadmiumApplication
        {
                public CadmiumApplication() { }

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
        }
}
