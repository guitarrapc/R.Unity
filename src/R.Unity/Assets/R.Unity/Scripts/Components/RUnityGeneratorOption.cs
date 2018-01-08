using UnityEngine;

namespace RUnity.Generator
{
    public class RUnityGeneratorOption : ScriptableObject
    {
        public string OutputPath = "Assets/Resources/RUnity.g.cs";
        public bool GenerateSceneNames = true;
        public bool GenerateFontNames = true;
        public bool GenerateShaderNames = true;
        public bool GenerateTagNames = true;
        public bool UseUnityLogger = true;
    }
}
