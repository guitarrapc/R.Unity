using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;
using RUnity.Generator.Extensions;

#if UNITY_EDITOR
namespace RUnity.Generator.Targets
{
    public class ResourcesTarget : ITarget
    {
        private static ILogger logger = new UnityLogger();

        public string ClassName { get { return "ResourceNames"; } }

        public string Generate()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Constants.Tab + @"public static class " + ClassName);
            builder.AppendLine(Constants.Tab + @"{");
            foreach (var item in GetCSharpSentence())
            {
                builder.AppendLine(Constants.DoubleTab + item);
            }
            builder.AppendLine(Constants.Tab + @"}");

            return builder.ToString();
        }

        private static string[] GetCSharpSentence()
        {
            var items = Search()
                .Select(x => new BuildSetting(x.Name, x.Path))
                .Select(x => x.GenerateCSharpSentence())
                .ToArray();
            return items;
        }

        private static ResourceInfo[] Search()
        {
            Debug.Log(Application.dataPath);
            // Search all folders except editor.
            var resources = Directory.GetDirectories(Application.dataPath, "Resources", SearchOption.AllDirectories)
                .SelectMany(x => new DirectoryInfo(x).GetFiles())
                .Where(x => !(x.Directory.FullName.Contains("editor") || x.Directory.FullName.Contains("Editor")))
                .Where(x => x.Extension != ".meta")
                .Select(x => x.FullName.Replace(@"\", "/"))
                .Select(x => x.Replace(Application.dataPath, ""))
                .Select(x => x.Substring(1, x.Length -1))
                .ToArray();

            // Get Root Resources
            var root = resources.Where(x => x.StartsWith("Resources", System.StringComparison.InvariantCultureIgnoreCase)).ToArray();

            // Get NonRoot Resources and sort by ABC (Alphabet).
            var nonRoot = resources.Except(root)
                .OrderBy(x => x)
                .Select(x =>
                {
                    var index = x.LastIndexOf("Resources", System.StringComparison.InvariantCultureIgnoreCase);
                    var name = x.Substring(index, x.Length - index).Replace("Resources/", "").Replace("resources/", "");
                    return new ResourceInfo(x, name);
                })
                .ToArray();

            // May include deplicate resource name
            var items = root.Select(x => new ResourceInfo(x, x.Replace("Resources/", "").Replace("resources/", "")))
                .Concat(nonRoot)
                .ToArray();

            // Remove Duplicates
            // Unity's same name picking up rule. (Perhaps....)
            // 1st check : Most min Depth first
            // 2nd check : ABC Order first
            // Depth first search by SubdirectoryCount for same Name resource.
            var duplicates = items.GroupBy(x => x.Name).Where(x => x.Count() > 1).ToArray();
            if (duplicates.Any())
            {
                // ABC order search
                var exceptDuplicates = duplicates.SelectMany(x => x.OrderBy(y => y.SubdirectoryCount).Skip(1));
                foreach (var item in exceptDuplicates)
                {
                    logger.Warning(item.Name + " : Resource name duplicated, not selected resource : " + "(" + item.Path + ")");
                }
                items = items.Except(exceptDuplicates).ToArray();
            }

            return items;
        }

        private struct ResourceInfo
        {
            public string Path;
            public string Name;
            public int SubdirectoryCount;

            public ResourceInfo(string path, string name)
            {
                Path = path;
                Name = name;
                SubdirectoryCount = Path.Replace("/" + Name, "").Count(y => y == '/');
            }
        }

        private struct BuildSetting
        {
            public string Name { get; set; }
            public string CSharpName { get; set; }
            public string Path { get; set; }
            public BuildSetting(string name, string path)
            {
                Name = name;
                Path = path;
                var validCharacterName = InvalidCharacterPairs.Replace(Path);
                var validKeyword = InvalidNames.Replace(validCharacterName);
                CSharpName = validKeyword;
            }

            public string GenerateCSharpSentence()
            {
                return "public static string " + CSharpName + " { get {return \"" + Name + "\";} }";
            }
        }
    }
}
#endif
