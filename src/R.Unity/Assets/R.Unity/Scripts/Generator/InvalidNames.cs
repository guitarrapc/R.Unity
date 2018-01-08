using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
namespace RUnity.Generator
{
    public static class InvalidNames
    {
        // reserved keywords for C#
        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/index
        private static string[] ReservedKeywords = new[]{
            "abstract", "as", "base", "bool",
            "break", "byte", "case", "catch",
            "char", "checked", "class", "const",
            "continue", "decimal", "default", "delegate",
            "do	double", "else", "enum",
            "event", "explicit", "extern", "false",
            "finally", "fixed", "float", "for",
            "foreach", "goto", "if", "implicit",
            "in", "in", "int", "interface",
            "internal", "is", "lock", "long",
            "namespace", "new", "null", "object",
            "operator", "out", "out", "override",
            "params", "private", "protected", "public",
            "readonly", "ref", "return", "sbyte",
            "sealed", "short", "sizeof", "stackalloc",
            "static", "string", "struct", "switch",
            "this", "throw", "true", "try",
            "typeof", "uint", "ulong", "unchecked",
            "unsafe", "ushort", "using", "using", "static",
            "virtual", "void", "volatile", "while",
        };

        public static string Replace(string value)
        {
            string input;
            if (TryReplaceInvalidString(value, out input))
            {
                return input;
            }
            else
            {
                return value;
            }
        }

        private static bool TryReplaceInvalidString(string name, out string value)
        {
            value = ReservedKeywords.Where(x => x == name).FirstOrDefault();
            if (value == null)
            {
                return false;
            }
            value = "_" + name + "_";
            return true;
        }
    }
}
#endif
