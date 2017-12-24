using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using RUnity.Generator.Targets;
#endif

#if UNITY_EDITOR
namespace RUnity.Generator
{
    public static class Generator
    {
        private static string outputPathDefault = "Assets/Resources/RUnity.g.cs";
        private static StringBuilder builder = new StringBuilder();

        // Generated file output path
        public static string OutputPath { get; private set; }
        public static bool EnableLogger { get; private set; }
        public static bool UseGeneratorSceneNames { get; set; }
        public static ILogger Logger { get; set; }

        private static bool Success { get; set; }

        static Generator()
        {
            UseGeneratorSceneNames = true;
            OutputPath = outputPathDefault;
            if (Logger == null)
            {
                Logger = new UnityLogger();
            }
        }

        public static void SetOutputPath(string path)
        {
            OutputPath = path;
        }

        public static bool Generate()
        {
            // Start NameSpace
            BeginNameSpace();

            // generate SceneNames
            var sceneClass = SceneNameTarget.Generate();
            Logger.Info(sceneClass);

            var fontClass = FontTarget.Generate();
            Logger.Info(fontClass);

            // Append Class;
            if (UseGeneratorSceneNames)
            {
                AppendClass(sceneClass);
            }
            AppendClass(fontClass);

            // End NameSpace
            EndNameSpace();

            // Generate to string
            var write = builder.ToString();

            // Write
            RemoveExisting();
            WriteNew(write);
            Success = true;

            // Refresh to Update Asset Database.
            if (Success)
            {
                Refresh();
            }
            return Success;
        }

        private static void BeginNameSpace()
        {
            // namespace RUnity
            // {
            // }
            builder.AppendLine(@"namespace RUnity");
            builder.AppendLine(@"{");
        }

        private static void EndNameSpace()
        {
            builder.AppendLine(@"}");
        }

        private static void AppendClass(string value)
        {
            builder.Append(value);
        }

        private static string GenerateString()
        {
            return builder.ToString();
        }

        private static void RemoveExisting()
        {
            if (File.Exists(OutputPath))
            {
                try
                {
                    File.Delete(OutputPath);
                }
                catch (System.Exception ex)
                {
                    Logger.Error(ex);
                    Success = false;
                }
            }
        }

        private static void WriteNew(string value)
        {
            var directory = Path.GetDirectoryName(OutputPath);
            if (!Directory.Exists(directory))
            {
                try
                {
                    Directory.CreateDirectory(directory);
                }
                catch (System.Exception ex)
                {
                    Logger.Error(ex);
                    Success = false;
                    return;
                }
            }

            File.AppendAllText(OutputPath, value, Encoding.UTF8);
        }

        public static void Refresh()
        {
            AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);
        }
    }
}
#endif
