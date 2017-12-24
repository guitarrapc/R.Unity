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
        private const string MenuGenerateSceneNames = "Tools/RUnity/Generate/SceneNames";

        [MenuItem(MenuGenerateSceneNames)]
        static void GenerateSceneNames()
        {
            Generator.Generate();
        }
    }
}
#endif