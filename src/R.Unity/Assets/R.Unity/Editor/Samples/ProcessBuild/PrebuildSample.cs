using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Callbacks;
#endif

#if UNITY_EDITOR
namespace RUnity.Generator.Editor.Samples.ProcessBuild
{
    public class Prebuild
    {
        public static void Sample()
        {
            Generator.Generate();
        }
    }
}
#endif