using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
using RUnity.Generator.Targets;
#endif

#if UNITY_EDITOR
namespace RUnity.Generator
{
    // Generate Following format class.
    // namespace RUnity
    // {
    //    public static class XxxxTarget
    //    {
    //    }
    //    public static class YxxxTarget
    //    {
    //    }
    //    public static class ZxxxTarget
    //    {
    //    }
    // }
    public static class Generator
    {
        private static readonly string OutputPathDefault = "Assets/Resources/RUnity.g.cs";
        private static readonly StringBuilder builder = new StringBuilder();
        private static readonly List<string> listString = new List<string>();

        // Generated file output path
        public static string OutputPath { get; private set; }
        public static bool UseGeneratorSceneNames { get; set; }
        public static bool UseGeneratorFontNames { get; set; }
        public static ILogger Logger { get; private set; }

        private static bool Success { get; set; }

        public static void SetOutputPath(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("OutputPath");
            OutputPath = path;
        }

        public static void SetLogger(ILogger logger)
        {
            if (logger == null) throw new ArgumentNullException("Logger");
            Logger = logger;
        }

        static Generator()
        {
            UseGeneratorSceneNames = true;
            UseGeneratorFontNames = true;
            OutputPath = OutputPathDefault;
            if (Logger == null)
            {
                Logger = new UnityLogger();
            }
        }

        public static bool GenerateAll()
        {
            // Initialize
            listString.Clear();

            // ITargets
            if (UseGeneratorSceneNames) GenerateClass(new SceneNameTarget());
            if (UseGeneratorFontNames) GenerateClass(new FontTarget());

            // Add NameSpace
            AddNameSpace();

            // Generate string
            foreach(var item in listString)
            {
                builder.AppendLine(item);
            }
            var write = builder.ToString();
            Logger.Info(write);

            // Write
            RemoveExisting();
            WriteNew(write);
            Success = true;

            // Refresh to Update Asset Database.
            if (Success)
            {
                AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);
            }
            return Success;
        }

        public static void GenerateClass(ITarget target)
        {
            // generate SceneNames
            var classItem = target.Generate();
            Logger.Info(classItem);

            // Generate to string
            listString.Add(classItem);
        }

        private static void AddNameSpace()
        {
            listString.Insert(0, @"namespace RUnity");
            listString.Insert(1, @"{");
            listString.Insert(listString.Count, @"}");
        }

        private static void AppendClass(string value)
        {
            builder.AppendLine(value);
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
    }
}
#endif
