## R.Unity

Get strong typed, *autocompleted* Unity string resources like Scenes, Tags, Layers, Shaders and Resources.

R.Unity is inspired from [R.swift](https://github.com/mac-cain13/R.swift)

## Why use this?

It makes your code that uses resources:

- **Editor menu checked**, no more incorrect strings that make your app crash at runtime.
- **Autocompleted**, never have to guess that resource name again.

Currently you type:

```csharp
var tag = GameObject.FindGameObjectWithTag("Player");
var font = new Font("Arial");
item.layer = LayerMask.NameToLayer("UI");
canvas.sortingLayerID = 1579608521;
var shader = Shader.Find("AR/TangoARRender");
SceneManager.LoadSceneAsync("Scenes/public");
```

With R.Unity it becomes:

```csharp
var tag = GameObject.FindGameObjectWithTag(RUnity.TagNames.Player);
var font = new Font(RUnity.FontNames.Arial);
item.layer = LayerMask.NameToLayer(RUnity.Layers.Names.UI);
canvas.sortingLayerID = RUnity.SortingLayers.Ids.Baskground;
var shader = RUnity.ShaderNames.Builtin.AR_Slash_TangoARRender;
SceneManager.LoadSceneAsync(RUnity.SceneNames.Scenes_Slash_public);
```

## Features

After installing R.Unity into your project you can use the `RUnity` static class to access resouces. If the static class is outated just run `Tools/RUnity/Generate/All` menu and RUnity will correct any missing/changed/added resources.

RUnity currently supports theses type of reousrces:

[TODO : Write example]
[TODO : Navigate to example]

- FontTarget 
- LayerTarget
- NavMeshAreaNameTarget
- ResourcesTarget
- SceneNameTarget
- ShaderTarget
- SortingLayerTarget
- TagTarget

## Installation

[TODO : Add UnityPakcage]
[TODO : AssetStore?]

## Limitation

[TODO : Errorhandling when type mismatch or type-miss generated.]

## License

R.Unity is created by Ikiru Yoshizaki and released under a MIT License.