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
                Generator.UseGeneratorSceneNames = option.UseGeneratorSceneNames;
                Generator.UseGeneratorFontNames = option.UseGeneratorFontNames;
                Generator.UseGeneratorShaderNames = option.UseGeneratorShaderNames;
                Generator.SetOutputPath(option.OutputPath);
                if (option.UseUnityLogger) Generator.SetLogger(new UnityLogger());
            }
            RUnity.Generator.Generator.GenerateAll();
        }
    }
}
#endif