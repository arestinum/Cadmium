using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadmium.Framework.Routing.Nodes
{
        public class HybridNode : INode
        {
                public string Name => throw new NotImplementedException();

                public List<ViewNode> Children { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
                public Dictionary<string, string> Parameters { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
                public NodeMetadata Metadata { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
                public string RelativePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
                public INodeConditions Condition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
                List<INode> INode.Children { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        }
}
