using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Example : MonoBehaviour
{
    public GameObject item;
    public Canvas canvas;

    void Start()
    {
        var tag = GameObject.FindGameObjectWithTag("Player");
        var font = new Font("Arial");
        item.layer = LayerMask.NameToLayer("UI");
        canvas.sortingLayerID = 1579608521;
        var shader = Shader.Find("AR/TangoARRender");
        SceneManager.LoadSceneAsync("Scenes/public");
    }

    private void OnEnable()
    {
        var tag = GameObject.FindGameObjectWithTag(RUnity.TagNames.Player);
        var font = new Font(RUnity.FontNames.Arial);
        item.layer = LayerMask.NameToLayer(RUnity.Layers.Names.UI);
        canvas.sortingLayerID = RUnity.SortingLayers.Ids.Baskground;
        var shader = RUnity.ShaderNames.Builtin.AR_Slash_TangoARRender;
        SceneManager.LoadSceneAsync(RUnity.SceneNames.Scenes_Slash_public);
    }
}
