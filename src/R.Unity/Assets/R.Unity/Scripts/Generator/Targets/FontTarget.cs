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
        public string Generate()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Constants.Tab + @"public static class FontNames");
            builder.AppendLine(Constants.Tab + @"{");
            foreach (var item in GetFonts())
            {
                builder.AppendLine(Constants.Tab + Constants.Tab + item);
            }
            builder.AppendLine(Constants.Tab + @"}");

            return builder.ToString();
        }

        private static string[] GetFonts()
        {
            var fonts = GetDefaultFonts()
                .Select(x => x.name)
                .Concat(SearchFont())
                .Select(x => new BuildSetting(x))
                .Select(x => x.GenerateCSharpSentence())
                .ToArray();
            return fonts;
        }

        private static Font[] GetDefaultFonts()
        {
            return new[] { Resources.GetBuiltinResource<Font>("Arial.ttf") };
        }

        private static string[] SearchFont()
        {
            // Search all folder include *font*.
            // TODO : Is this right way to search fonts?
            // TODO : Should I just search by extensions?
            // TODO : Or Should I set extensions to path folder?
            var fonts = Directory.GetDirectories(Application.dataPath, "*font*", SearchOption.AllDirectories)
                .SelectMany(x => new DirectoryInfo(x).GetFiles())
                .Where(x => x.Extension == ".ttf" || x.Extension == ".otf")
                .Select(x => Path.GetFileNameWithoutExtension(x.Name))
                .ToArray();
            return fonts;
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
