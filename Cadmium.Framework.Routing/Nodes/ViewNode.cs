using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadmium.Framework.Routing.Nodes
{
        public class ViewNode : INode
        {
                public List<INode> Children { get; set; } = new List<INode>();

                public string Name { get; set; }

                public Dictionary<string, string> Parameters { get; set; }
                
                public NodeMetadata Metadata { get; set; }

                public string RelativePath { get; set; }
                
                public INodeConditions Condition { get; set; }
        }
}
