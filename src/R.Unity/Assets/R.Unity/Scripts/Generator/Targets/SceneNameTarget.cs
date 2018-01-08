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
        public string Generate()
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
                .Select(x => new BuildSetting(GetScene(x.path)))
                .Select(x => x.GenerateCSharpSentence())
                .ToArray();
            return scenes;
        }

        private static string GetScene(string path)
        {
            return System.IO.Path.ChangeExtension(path.Replace("Assets/", ""), null);
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
