using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;
using System.Reflection;
#if UNITY_EDITOR
using UnityEditorInternal;
#endif

#if UNITY_EDITOR
namespace RUnity.Generator.Targets
{
    public class SortingLayerTarget : ITarget
    {
        public string ClassName { get { return "SortingLayers"; } }
        public string Generate()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Constants.Tab + @"public static class " + ClassName);
            builder.AppendLine(Constants.Tab + @"{");
            builder.AppendLine(Constants.DoubleTab + @"public static class Names");
            builder.AppendLine(Constants.DoubleTab + @"{");
            foreach (var item in GetCSharpSentence().Select(x => x.GenerateCSharpSentence()))
            {
                builder.AppendLine(Constants.TripleTab + item);
            }
            builder.AppendLine(Constants.DoubleTab + @"}");

            builder.AppendLine(Constants.DoubleTab + @"public static class Ids");
            builder.AppendLine(Constants.DoubleTab + @"{");
            foreach (var item in GetCSharpSentence().Select(x => x.GenerateCSharpIdSentence()))
            {
                builder.AppendLine(Constants.TripleTab + item);
            }
            builder.AppendLine(Constants.DoubleTab + @"}");
            builder.AppendLine(Constants.Tab + @"}");

            return builder.ToString();
        }

        private static BuildSetting[] GetCSharpSentence()
        {
            var items = Search()
                .Select(x => new BuildSetting(x.Name, x.Id))
                .ToArray();
            return items;
        }

        private static SortingLayerInfo[] Search()
        {
            // Reflection to get sortinglayers
            // https://answers.unity.com/questions/585108/how-do-you-access-sorting-layers-via-scripting.html
            var sortingLayerProperties = typeof(InternalEditorUtility).GetProperty("sortingLayerNames", BindingFlags.Static | BindingFlags.NonPublic);
            var sortingLayers = sortingLayerProperties.GetValue(null, new object[0]) as string[];
            var items = sortingLayers.Select(x => new SortingLayerInfo(x, SortingLayer.NameToID(x))).ToArray();
            return items;
        }

        private struct SortingLayerInfo
        {
            public string Name { get; set; }
            public int Id { get; set; }

            public SortingLayerInfo(string name, int id) : this()
            {
                Name = name;
                Id = id;
            }
        }

        private struct BuildSetting
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public string CSharpName { get; set; }
            public BuildSetting(string name, int id)
            {
                Name = name;
                Id = id;
                var validCharacterName = InvalidCharacterPairs.Replace(name);
                var validKeyword = InvalidNames.Replace(validCharacterName);
                CSharpName = validKeyword;
            }

            public string GenerateCSharpSentence()
            {
                return "public static string " + CSharpName + " { get {return \"" + Name + "\";} }";
            }

            public string GenerateCSharpIdSentence()
            {
                return "public static string " + CSharpName + " { get {return \"" + Id + "\";} }";
            }
        }
    }
}
#endif
