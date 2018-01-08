using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

#if UNITY_EDITOR
namespace RUnity.Generator.Targets
{
    public class FontTarget : ITarget
    {
        private static readonly Font[] builtinFonts = new[]
        {
            Resources.GetBuiltinResource<Font>("Arial.ttf"),
        };

        public string ClassName { get { return "FontNames"; } }
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
            var items = SearchBuiltin()
                .Select(x => x.name)
                .Concat(Search())
                .Select(x => new BuildSetting(x))
                .Select(x => x.GenerateCSharpSentence())
                .ToArray();
            return items;
        }

        private static Font[] SearchBuiltin()
        {
            return builtinFonts;
        }

        private static string[] Search()
        {
            // Search all folders except editor.
            var items = Directory.GetFiles(Application.dataPath, "*", SearchOption.AllDirectories)
                .SelectMany(x => new DirectoryInfo(x).GetFiles())
                .Where(x => !(x.Directory.FullName.Contains("editor") || x.Directory.FullName.Contains("Editor")))
                .Where(x => x.Extension == ".ttf" || x.Extension == ".otf")
                .Select(x => Path.GetFileNameWithoutExtension(x.Name))
                .ToArray();
            return items;
        }

        private struct BuildSetting
        {
            public string Name { get; set; }
            public string CSharpName { get; set; }
            public BuildSetting(string name)
            {
                Name = name;
                var validCharacterName = InvalidCharacterPairs.Replace(name);
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
