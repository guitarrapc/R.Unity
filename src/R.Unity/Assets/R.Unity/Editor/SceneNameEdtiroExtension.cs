using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
namespace RUnity.Generator.Editor.EditorExtension
{
    public class SceneNameEditorExtension : EditorWindow
    {
        private const string MenuGenerateAll = "Tools/RUnity/Generate/All";
        private const string MenuGenerateSceneNames = "Tools/RUnity/Generate/SceneNames";
        private const string MenuGenerateFontNames = "Tools/RUnity/Generate/FontNamess";

        private const string MenuCreateRUnityScriptableObject = "Tools/RUnity/Create RUnityOption";
        private const string MenuRightClickCreateRUnityScriptableObject = "Assets/Create/RUnity/Create RUnityOption";

        private static readonly string RUnityOptionPath = "Assets/RUnityOption.asset";

        [MenuItem(MenuGenerateAll)]
        static void GenerateAll()
        {
            Generator.GenerateAll();
        }

        [MenuItem(MenuGenerateSceneNames)]
        static void GenerateSceneNames()
        {
            Generator.GenerateAll();
        }

        [MenuItem(MenuGenerateFontNames)]
        static void GenerateFontNames()
        {
            Generator.GenerateAll();
        }

        [MenuItem(MenuCreateRUnityScriptableObject)]
        static void CreateRUnityOption()
        {
            // Instantiate
            var item = ScriptableObject.CreateInstance<RUnityGeneratorOption>();
            var path = AssetDatabase.GenerateUniqueAssetPath(RUnityOptionPath);
            AssetDatabase.CreateAsset(item, path);
            AssetDatabase.SaveAssets();

            // Focus
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = item;
        }

        [MenuItem(MenuRightClickCreateRUnityScriptableObject, false, 0)]
        static void CreateAsset()
        {
            var script = Selection.activeObject as MonoScript;
            Create(typeof(RUnityGeneratorOption), RUnityOptionPath);
        }

        static void Create(System.Type type, string path)
        {
            ProjectWindowUtil.CreateAsset(CreateInstance(type), path);
        }
    }
}
#endif