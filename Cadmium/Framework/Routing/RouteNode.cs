using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cadmium.Framework.Routing
{
    public class RouteNode
    {
        public string RelativePath { get; set; }
        public string AbsolutePath { get; set; }
        public string Pattern { get; set; }
        public string FolderName { get; set; }
        public string Name 
        { 
            get 
            { 
                if (Metadata != null)
                    return string.IsNullOrEmpty(Metadata.RouteNodeName) ? FolderName.ToLower() : Metadata.RouteNodeName;

                return FolderName;
            } 
        }
        public List<RouteNode> Children { get; set; }
        public RouteNodeConditions Condition { get; set; }
        public Dictionary<string, string> RouteParameters { get; set; }
        public RouteMetadata Metadata { get; set; } 
    }
}