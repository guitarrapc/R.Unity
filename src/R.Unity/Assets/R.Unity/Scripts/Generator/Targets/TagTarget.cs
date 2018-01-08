using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditorInternal;
#endif

#if UNITY_EDITOR
namespace RUnity.Generator.Targets
{
    public class TagTarget : ITarget
    {
        public string ClassName { get { return "TagNames"; } }
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
                .Select(x => new BuildSetting(x))
                .Select(x => x.GenerateCSharpSentence())
                .ToArray();
            return items;
        }

        private static string[] Search()
        {
            // Search all folders except editor.
            var items = InternalEditorUtility.tags;
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
