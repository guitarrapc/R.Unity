using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
namespace RUnity.Generator
{
    public static class SceneNames
    {
        public static string Generate()
        {
            var builder = new StringBuilder();
            builder.AppendLine(@"    public static class SceneNames");
            builder.AppendLine(@"    {");
            foreach (var item in GenerateSceneNames())
            {
                builder.AppendLine(@"        " + item);
            }
            builder.AppendLine(@"    }");

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

        // Not acceptable chars for C# spec "2.4.5 Operators and punctuators"
        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/
        // https://github.com/dotnet/csharplang/blob/master/spec/README.md
        // symbol name reference : https://www.prepressure.com/fonts/basics/character-names
        private static readonly InvalidCharacterPairs[] invalidCharacters = new[]
        {
            new InvalidCharacterPairs(' ', "Space"),
            new InvalidCharacterPairs('!', "Exclamation"),
            new InvalidCharacterPairs('"', "Doublequote"),
            new InvalidCharacterPairs('#', "Hash"),
            new InvalidCharacterPairs('$', "Dollar"),
            new InvalidCharacterPairs('%', "Percent"),
            new InvalidCharacterPairs('&', "Ampersand"),
            new InvalidCharacterPairs('\'', "Apostrophe"),
            new InvalidCharacterPairs('(', "Leftparenthesis"),
            new InvalidCharacterPairs(')', "Rightparenthesis"),
            new InvalidCharacterPairs('-', "Hyphen"),
            new InvalidCharacterPairs('=', "Equals"),
            new InvalidCharacterPairs('^', "Circumflex"),
            new InvalidCharacterPairs('~', "Tilde"),
            new InvalidCharacterPairs('"', "Backslash"),
            new InvalidCharacterPairs('|', "Pipe"),
            new InvalidCharacterPairs('@', "At"),
            new InvalidCharacterPairs('`', "Backquote"),
            new InvalidCharacterPairs('[', "Leftbracket"),
            new InvalidCharacterPairs(']', "Rightbracket"),
            new InvalidCharacterPairs('{', "Leftcurlybracket"),
            new InvalidCharacterPairs('}', "Rightcurlybracket"),
            new InvalidCharacterPairs(';', "Semicolon"),
            new InvalidCharacterPairs('+', "Plus"),
            new InvalidCharacterPairs(':', "Colon"),
            new InvalidCharacterPairs('*', "Asterisk"),
            new InvalidCharacterPairs(',', "Comma"),
            new InvalidCharacterPairs('.', "Period"),
            new InvalidCharacterPairs('<', "Lessthan"),
            new InvalidCharacterPairs('>', "Greaterthan"),
            new InvalidCharacterPairs('/', "Slash"),
            new InvalidCharacterPairs('?', "Question"),
        };

        private static readonly InvalidCharacterPairs[] invalidStartsWithCharacters = new[]
        {
            new InvalidCharacterPairs('1', "One"),
            new InvalidCharacterPairs('2', "Two"),
            new InvalidCharacterPairs('3', "Three"),
            new InvalidCharacterPairs('4', "Four"),
            new InvalidCharacterPairs('5', "Five"),
            new InvalidCharacterPairs('6', "Six"),
            new InvalidCharacterPairs('7', "Seven"),
            new InvalidCharacterPairs('8', "Eight"),
            new InvalidCharacterPairs('9', "Nine"),
            new InvalidCharacterPairs('0', "Ten"),
        };

        private struct BuildSettingScenes
        {
            public string Path { get; set; }
            public string Name { get; set; }
            public string CSharpName { get; set; }
            public BuildSettingScenes(string path, string name)
            {
                Path = path;
                Name = name;
                CSharpName = Replace(name);
            }

            public string GenerateCSharpSentence()
            {
                return "public static readonly string " + CSharpName + " = \"" + Name + "\";";
            }

            private static string Replace(string value)
            {
                string result = "";

                // Class first char should not contains InvalidChars and Numbers.
                foreach (var c in value.Take(1))
                {
                    string input;
                    if (TryReplaceInvalidChar(c, out input))
                    {
                        result += input;
                    }
                    else if (TryReplaceInvalidStartWith(c, out input))
                    {
                        result += input;
                    }
                    else
                    {
                        result += c;
                    }
                    result.ToUpperInvariant();
                }

                // Class other char should not contains InvalidChars.
                foreach (var c in value.Skip(1))
                {
                    string input;
                    if (TryReplaceInvalidChar(c, out input))
                    {
                        result += input;
                    }
                    else
                    {
                        result += c;
                    }
                }
                return result;
            }

            private static bool TryReplaceInvalidChar(char c, out string value)
            {
                value = invalidCharacters.Where(x => x.TargetChar == c).Select(x => x.ReplaceString).FirstOrDefault();
                if (value == null)
                {
                    return false;
                }
                return true;
            }

            private static bool TryReplaceInvalidStartWith(char c, out string value)
            {
                value = invalidStartsWithCharacters.Where(x => x.TargetChar == c).Select(x => x.ReplaceString).FirstOrDefault();
                if (value == null)
                {
                    return false;
                }
                return true;
            }
        }

        private struct InvalidCharacterPairs
        {
            public char TargetChar { get; set; }
            public string ReplaceString { get; set; }

            public InvalidCharacterPairs(char targetChar, string replaceString)
            {
                TargetChar = targetChar;
                ReplaceString = "_" + replaceString + "_";
            }
        }
    }
}
#endif
