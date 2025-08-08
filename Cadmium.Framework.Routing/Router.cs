using Cadmium.Framework.Routing.Nodes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cadmium.Framework.Routing
{
        /// <summary>
        /// The Router class is dedicated to build up the root routing trees. 
        /// <br/>
        /// 
        /// </summary>
        public class Router
        {
                public Router() 
                {
                        Discover();
                }

                public List<Tree> Routes { get; set; } = new List<Tree>();

                public INode Traverse(List<string> segments)
                {
                        throw new NotImplementedException();
                }

                public void Discover() 
                {
                        string[] rootRouteFolders = Directory.GetDirectories(
                                Path.Combine(
                                        AppDomain.CurrentDomain.BaseDirectory, "Routes"
                                )
                        );

                        foreach (var rootRouteFolder in rootRouteFolders)
                        {
                                INode node = new ViewNode 
                                { 
                                        Name = rootRouteFolder.Split('\\').Last(),
                                        RelativePath = "hi",
                                        Children = [.. Directory.GetDirectories(rootRouteFolder).Select(directory => new ViewNode { Name = directory.Split('\\').Last() })],
                                };

                                Routes.Add(new Tree {
                                        RootNode = node
                                });
                        }
                }
        }
}
