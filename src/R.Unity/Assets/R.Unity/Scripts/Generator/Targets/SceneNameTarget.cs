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
    public static class SceneNameTarget
    {
        public static string Generate()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Constants.Tab + @"public static class SceneNames");
            builder.AppendLine(Constants.Tab + @"{");
            foreach (var item in GetSceneNames())
            {
                builder.AppendLine(Constants.Tab + Constants.Tab + item);
            }
            builder.AppendLine(Constants.Tab + @"}");

            return builder.ToString();
        }

        private static string[] GetSceneNames()
        {
            var scenes = EditorBuildSettings.scenes
                .Select(x => new BuildSetting(x.path, System.IO.Path.GetFileNameWithoutExtension(x.path)))
                .Select(x => x.GenerateCSharpSentence())
                .ToArray();
            return scenes;
        }

        private struct BuildSetting
        {
            public string Path { get; set; }
            public string Name { get; set; }
            public string CSharpName { get; set; }
            public BuildSetting(string path, string name)
            {
                Path = path;
                Name = name;
                CSharpName = InvalidCharacterPairs.Replace(name);
            }

            public string GenerateCSharpSentence()
            {
                return "public static string " + CSharpName + " { get {return \"" + Name + "\";} }";
            }
        }
    }
}
#endif
