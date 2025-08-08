using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadmium.Framework.Routing.Nodes
{
        internal class ViewNode : INode
        {
                public List<ViewNode> Children { get; set; } = new List<ViewNode>();

                public string Name => string.Empty;

                public Dictionary<string, string> Parameters { get; set; }
                
                public NodeMetadata Metadata { get; set; }
        }
}
