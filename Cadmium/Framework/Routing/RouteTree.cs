using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;

namespace Cadmium.Framework.Routing
{
    public class RouteTree
    {
        public RouteTree(string rootDirectoryPath) 
        {
            RelativeRootDirectoryPath = rootDirectoryPath;
            RootDirectoryPath = rootDirectoryPath;
            Root = BuildTree(rootDirectoryPath);
        }

        public string RelativeRootDirectoryPath;
        public string RootDirectoryPath;
        public virtual RouteNode Root { get; set; }

        public RouteNode BuildTree(string path)
        {
            string folderName = path.Split('\\').Last();
            string[] childrenPaths = Directory.GetDirectories(path);

            RouteMetadata metadata = null;
            string metadataFilePath = $"{path}\\metadata.json";
            bool hasMetadataFile = File.Exists(metadataFilePath);
            if (hasMetadataFile)
                metadata = JsonSerializer.Deserialize<RouteMetadata>(File.ReadAllText($"{path}\\metadata.json"), new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            RouteNodeConditions conditions = new RouteNodeConditions 
            {
                HasDefault = File.Exists($"{path}\\Default.aspx"),
                HasDynamicRoute = childrenPaths
                        .Select(childPath => {
                            string childPathName = childPath.Split('\\').Last();
                            return childPathName.StartsWith("[") && childPathName.EndsWith("]");
                        })
                        .Contains(true),
            };

            return new RouteNode()
            {
                RelativePath = path.Substring(path.IndexOf("Routes\\")).Replace("\\", "/"),
                AbsolutePath = path.Replace("\\", "/"),
                Pattern = Regex.Replace(path.Substring(path.IndexOf("Routes\\")).Replace("\\", "/"), @"\[.{0,}\]", "([^/]+)\")}/?$").ToLower(),
                FolderName = folderName,
                Children = childrenPaths.Select(childPath => BuildTree(childPath)).ToList(),
                Condition = conditions,  
                RouteParameters = new Dictionary<string, string>(),
                Metadata = metadata
            };
        }
    }
}