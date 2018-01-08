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

        // Generated file output path
        public static string OutputPath { get; private set; }
        public static bool GenerateSceneNames { get; set; }
        public static bool GenerateFontNames { get; set; }
        public static bool GenerateShaderNames { get; set; }
        public static bool GenerateTagNames { get; set; }
        public static bool GenerateLayers { get; set; }
        public static bool GenerateSortingLayers { get; set; }
        public static bool GenerateNavMeshAreaNames { get; set; }
        public static bool GenerateResourceNames { get; set; }
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
            GenerateSceneNames = true;
            GenerateFontNames = true;
            GenerateShaderNames = true;
            GenerateTagNames = true;
            GenerateLayers = true;
            GenerateSortingLayers = true;
            GenerateNavMeshAreaNames = true;
            GenerateResourceNames = true;
            OutputPath = OutputPathDefault;
            if (Logger == null)
            {
                Logger = new UnityLogger();
            }
        }

        public static bool GenerateAll()
        {
            // Initialize
            var listString = new List<string>();

            // ITargets
            if (GenerateSceneNames) GenerateClass(new SceneNameTarget(), listString);
            if (GenerateFontNames) GenerateClass(new FontTarget(), listString);
            if (GenerateShaderNames) GenerateClass(new ShaderTarget(), listString);
            if (GenerateTagNames) GenerateClass(new TagTarget(), listString);
            if (GenerateLayers) GenerateClass(new LayerTarget(), listString);
            if (GenerateSortingLayers) GenerateClass(new SortingLayerTarget(), listString);
            if (GenerateNavMeshAreaNames) GenerateClass(new NavMeshAreaNameTarget(), listString);
            if (GenerateResourceNames) GenerateClass(new ResourcesTarget(), listString);

            // Add NameSpace
            listString.Insert(0, @"namespace RUnity");
            listString.Insert(1, @"{");
            listString.Insert(listString.Count, @"}");

            // Generate string
            var builder = new StringBuilder();
            foreach (var item in listString)
            {
                builder.AppendLine(item);
            }
            var write = builder.ToString();
            Logger.Info(write);

            // clean up
            builder = null;
            listString.Clear();
            listString = null;

            // Write
            WriteNew(write);
            Success = true;

            // Refresh to Update Asset Database.
            if (Success)
            {
                AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);
            }
            return Success;
        }

        public static void GenerateClass(ITarget target, List<string> listString)
        {
            // generate SceneNames
            var classItem = target.Generate();
            Logger.Info(classItem);

            // Generate to string
            listString.Add(classItem);
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

            File.WriteAllText(OutputPath, value, Encoding.UTF8);
        }
    }
}
#endif
