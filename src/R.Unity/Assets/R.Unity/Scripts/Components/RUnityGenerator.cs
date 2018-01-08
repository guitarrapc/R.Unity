using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
namespace RUnity.Generator
{
    public class RUnityGenerator : MonoBehaviour
    {
        public RUnityGeneratorOption option = null;
        void Start()
        {
            if (option != null)
            {
                Generator.GenerateSceneNames = option.GenerateSceneNames;
                Generator.GenerateFontNames = option.GenerateFontNames;
                Generator.GenerateShaderNames = option.GenerateShaderNames;
                Generator.GenerateTagNames = option.GenerateTagNames;
                Generator.GenerateLayers = option.GenerateLayers;
                Generator.GenerateSortingLayers = option.GenerateSoringLayers;
                Generator.GenerateNavMeshAreaNames = option.GenerateNavMeshAreaNames;
                Generator.SetOutputPath(option.OutputPath);
                if (option.UseUnityLogger) Generator.SetLogger(new UnityLogger());
            }
            RUnity.Generator.Generator.GenerateAll();
        }
    }
}
#endif