using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
namespace RUnity.Generator.Targets
{
    public class SceneNameTarget : ITarget
    {
        public string ClassName { get { return "SceneNames"; } }

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
            var items = EditorBuildSettings.scenes
                .Select(x => System.IO.Path.ChangeExtension(x.path.Replace("Assets/", ""), null))
                .ToArray();
            return items;
        }

        private struct BuildSetting
        {
            public string Path { get; set; }
            public string CSharpName { get; set; }
            public BuildSetting(string path)
            {
                Path = System.IO.Path.ChangeExtension(path.Replace("Assets/", ""), null);
                var validCharacterName = InvalidCharacterPairs.Replace(Path);
                var validKeyword = InvalidNames.Replace(validCharacterName);
                CSharpName = validKeyword;
            }

            public string GenerateCSharpSentence()
            {
                return "public static string " + CSharpName + " { get {return \"" + Path + "\";} }";
            }
        }
    }
}
#endif
