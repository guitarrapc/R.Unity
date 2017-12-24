using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUnityTest : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        //RUnity.Generator.Generator.UseGeneratorSceneNames = false;
        RUnity.Generator.Generator.Generate();
    }
}