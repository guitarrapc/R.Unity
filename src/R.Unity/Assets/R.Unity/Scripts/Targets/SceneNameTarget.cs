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
            builder.AppendLine(Generator.Tab + @"public static class SceneNames");
            builder.AppendLine(Generator.Tab + @"{");
            foreach (var item in GenerateSceneNames())
            {
                builder.AppendLine(Generator.Tab + Generator.Tab + item);
            }
            builder.AppendLine(Generator.Tab + @"}");

            return builder.ToString();
        }

        private static string[] GenerateSceneNames()
        {
            var scenes = EditorBuildSettings.scenes
                .Select(x => new BuildSettingScenes(x.path, System.IO.Path.GetFileNameWithoutExtension(x.path)))
                .Select(x => x.GenerateCSharpSentence())
                .ToArray();
            return scenes;
        }

        private struct BuildSettingScenes
        {
            public string Path { get; set; }
            public string Name { get; set; }
            public string CSharpName { get; set; }
            public BuildSettingScenes(string path, string name)
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
