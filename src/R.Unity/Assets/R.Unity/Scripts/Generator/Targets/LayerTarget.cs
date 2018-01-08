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
    public class LayerTarget : ITarget
    {
        public string ClassName { get { return "Layers"; } }
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

        private static LayerInfo[] Search()
        {
            var items = InternalEditorUtility.layers.Select(x => new LayerInfo(x, LayerMask.NameToLayer(x))).ToArray();
            return items;
        }

        private struct LayerInfo
        {
            public string Name { get; set; }
            public int Id { get; set; }

            public LayerInfo(string name, int id) : this()
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
                return "public static int " + CSharpName + " { get {return " + Id + ";} }";
            }
        }
    }
}
#endif
