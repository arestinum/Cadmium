using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Web;

namespace Cadmium.Framework.Routing
{
    public class RouteTree
    {
        public RouteTree(string rootDirectoryPath) 
        {
            RelativeRootDirectoryPath = rootDirectoryPath;
            RootDirectoryPath = rootDirectoryPath;
            BuildTree();
        }

        public string RelativeRootDirectoryPath;
        public string RootDirectoryPath;
        public virtual RouteNode Root { get; set; }

        public void BuildTree()
        {
            string[] childrenPaths = Directory.GetDirectories(RootDirectoryPath);
            IEnumerable<RouteMetadata> routeMetadatas = childrenPaths.Select(childPath =>
            {
                if (File.Exists(Path.Combine(childPath, "\\metadata.json")))
                    return JsonSerializer.Deserialize<RouteMetadata>(File.ReadAllText(Path.Combine(childPath, "\\metadata.json")));

                return null;
            });

            RouteMetadata metadata = null;
            string metadataFilePath = $"{RootDirectoryPath}\\metadata.json";
            bool hasMetadataFile = File.Exists(metadataFilePath);
            if (hasMetadataFile)
                metadata = JsonSerializer.Deserialize<RouteMetadata>(File.ReadAllText($"{RootDirectoryPath}\\metadata.json"), new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            Root = new RouteNode()
            {
                AbsolutePath = metadataFilePath,
                FolderName = RootDirectoryPath.Split('\\').Last(),
                Children = childrenPaths.Select(childPath => {
                    return new RouteNode()
                    {
                        AbsolutePath = childPath,
                    }; 
                }).ToList(),
                Condition = new RouteNodeConditions
                {
                    HasDefault = File.Exists(
                        Path.Combine(RootDirectoryPath, "\\Default.aspx")
                    ),
                    HasDynamicRoute = childrenPaths
                        .Select(childPath => {
                            string childPathName = childPath.Split('\\').Last();
                            return childPathName.StartsWith("[") && childPathName.EndsWith("]");
                        })
                        .Contains(true),
                },  
                RouteParameters = new Dictionary<string, string>(),
                Metadata = metadata
            };
        }
    }
}