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
    public static class Generator
    {
        private static string outputPathDefault = "Assets/Resources/RUnity.g.cs";
        // Generated file output path
        public static string OutputPath { get; private set; }
        private static bool Success { get; set; }

        static Generator()
        {
            OutputPath = outputPathDefault;
        }

        public static void SetOutputPath(string path)
        {
            OutputPath = path;
        }

        public static bool Generate()
        {
            // generate SceneNames
            var sceneClass = SceneNames.Generate();
            Debug.Log(sceneClass);

            RemoveClass();
            WriteClass(sceneClass);
            Success = true;

            if (Success)
            {
                Refresh();
            }
            return Success;
        }

        private static void RemoveClass()
        {
            if (File.Exists(OutputPath))
            {
                try
                {
                    File.Delete(OutputPath);
                }
                catch (System.Exception ex)
                {
                    Debug.LogError(ex);
                    Success = false;
                }
            }
        }

        private static void WriteClass(string value)
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
                    Debug.LogError(ex);
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
