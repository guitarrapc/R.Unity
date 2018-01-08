using UnityEngine;

namespace RUnity.Generator
{
    public class RUnityGeneratorOption : ScriptableObject
    {
        public string OutputPath = "Assets/Resources/RUnity.g.cs";
        public bool UseGeneratorSceneNames = true;
        public bool UseGeneratorFontNames = true;
        public bool UseUnityLogger = true;
    }
}
