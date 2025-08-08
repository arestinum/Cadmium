using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadmium.Framework.Routing.Nodes
{
        internal interface INode
        {
                string Name { get; }
                
                List<ViewNode> Children { get; set; }
                
                /// <summary>
                /// It is a map containing the URL parameter's name and its value.
                /// </summary>
                Dictionary<string, string> Parameters { get; set; }

                /// <summary>
                /// The metadata is serialised from the named JSON file within the node's folder. 
                /// <br/>
                /// Contains configuration providing a way to rename the internal name to an external one.
                /// </summary>
                NodeMetadata Metadata { get; set; }
        }
}
