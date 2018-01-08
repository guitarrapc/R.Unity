using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

#if UNITY_EDITOR
namespace RUnity.Generator.Targets
{
    public class ShaderTarget : ITarget
    {
        // Pickup shadername linqpad code.
        //var basePath = @"C:\Users\UserName\Downloads\builtin_shaders-2017.3.0f3";
        //Directory.EnumerateFiles(basePath, "*.shader", SearchOption.AllDirectories)
        //.SelectMany(x => File.ReadLines(x))
        //.Where(x => x.Contains("Shader \""))
        //.Select(x => x.Replace("Shader ", ""))
        //.Select(x => x.Replace(" {", ""))
        //.Select(x => x + ",")
        //.Where(x => !x.StartsWith("\"Hidden"))
        //.OrderBy(x => x)
        //.Dump();
        private static readonly string[] buildinShaders = new[] {
#if UNITY_2017_3
            #region 2017.3.x : 109 items
            "AR/TangoARRender",
            "FX/Flare",
            "GUI/Text Shader",
            "Legacy Shaders/Bumped Diffuse",
            "Legacy Shaders/Bumped Specular",
            "Legacy Shaders/Decal",
            "Legacy Shaders/Diffuse Detail",
            "Legacy Shaders/Diffuse Fast",
            "Legacy Shaders/Diffuse",
            "Legacy Shaders/Lightmapped/Bumped Diffuse",
            "Legacy Shaders/Lightmapped/Bumped Specular",
            "Legacy Shaders/Lightmapped/Diffuse",
            "Legacy Shaders/Lightmapped/Specular",
            "Legacy Shaders/Lightmapped/VertexLit",
            "Legacy Shaders/Parallax Diffuse",
            "Legacy Shaders/Parallax Specular",
            "Legacy Shaders/Reflective/Bumped Diffuse",
            "Legacy Shaders/Reflective/Bumped Specular",
            "Legacy Shaders/Reflective/Bumped Unlit",
            "Legacy Shaders/Reflective/Bumped VertexLit",
            "Legacy Shaders/Reflective/Diffuse",
            "Legacy Shaders/Reflective/Parallax Diffuse",
            "Legacy Shaders/Reflective/Parallax Specular",
            "Legacy Shaders/Reflective/Specular",
            "Legacy Shaders/Reflective/VertexLit",
            "Legacy Shaders/Self-Illumin/Bumped Diffuse",
            "Legacy Shaders/Self-Illumin/Bumped Specular",
            "Legacy Shaders/Self-Illumin/Diffuse",
            "Legacy Shaders/Self-Illumin/Parallax Diffuse",
            "Legacy Shaders/Self-Illumin/Parallax Specular",
            "Legacy Shaders/Self-Illumin/Specular",
            "Legacy Shaders/Self-Illumin/VertexLit",
            "Legacy Shaders/Specular",
            "Legacy Shaders/Transparent/Bumped Diffuse",
            "Legacy Shaders/Transparent/Bumped Specular",
            "Legacy Shaders/Transparent/Cutout/Bumped Diffuse",
            "Legacy Shaders/Transparent/Cutout/Bumped Specular",
            "Legacy Shaders/Transparent/Cutout/Diffuse",
            "Legacy Shaders/Transparent/Cutout/Soft Edge Unlit",
            "Legacy Shaders/Transparent/Cutout/Specular",
            "Legacy Shaders/Transparent/Cutout/VertexLit",
            "Legacy Shaders/Transparent/Diffuse",
            "Legacy Shaders/Transparent/Parallax Diffuse",
            "Legacy Shaders/Transparent/Parallax Specular",
            "Legacy Shaders/Transparent/Specular",
            "Legacy Shaders/Transparent/VertexLit",
            "Legacy Shaders/VertexLit",
            "Mobile/Bumped Diffuse",
            "Mobile/Bumped Specular (1 Directional Light)",
            "Mobile/Bumped Specular",
            "Mobile/Diffuse",
            "Mobile/Particles/Additive",
            "Mobile/Particles/Alpha Blended",
            "Mobile/Particles/Multiply",
            "Mobile/Particles/VertexLit Blended",
            "Mobile/Skybox",
            "Mobile/Unlit (Supports Lightmap)",
            "Mobile/VertexLit (Only Directional Lights)",
            "Mobile/VertexLit",
            "Nature/SpeedTree Billboard",
            "Nature/SpeedTree",
            "Nature/Terrain/Diffuse",
            "Nature/Terrain/Specular",
            "Nature/Terrain/Standard",
            "Nature/Tree Creator Bark",
            "Nature/Tree Creator Leaves Fast",
            "Nature/Tree Creator Leaves",
            "Nature/Tree Soft Occlusion Bark",
            "Nature/Tree Soft Occlusion Leaves",
            "Particles/~Additive-Multiply",
            "Particles/Additive (Soft)",
            "Particles/Additive",
            "Particles/Alpha Blended Premultiply",
            "Particles/Alpha Blended",
            "Particles/Anim Alpha Blended",
            "Particles/Blend",
            "Particles/Multiply (Double)",
            "Particles/Multiply",
            "Particles/Standard Surface",
            "Particles/Standard Unlit",
            "Particles/VertexLit Blended",
            "Skybox/6 Sided",
            "Skybox/Cubemap",
            "Skybox/Panoramic",
            "Skybox/Procedural",
            "Sprites/Default",
            "Sprites/Diffuse",
            "Sprites/Mask",
            "Standard (Roughness setup)",
            "Standard (Specular setup)",
            "Standard",
            "UI/Default Font",
            "UI/Default",
            "UI/DefaultETC1",
            "UI/Lit/Bumped",
            "UI/Lit/Detail",
            "UI/Lit/Refraction Detail",
            "UI/Lit/Refraction",
            "UI/Lit/Transparent",
            "UI/Unlit/Detail",
            "UI/Unlit/Text Detail",
            "UI/Unlit/Text",
            "UI/Unlit/Transparent",
            "Unlit/Color",
            "Unlit/Texture",
            "Unlit/Transparent Cutout",
            "Unlit/Transparent",
            "VR/SpatialMapping/Occlusion",
            "VR/SpatialMapping/Wireframe",
            #endregion
#elif UNITY_2017_2
            #region 2017.x : 106 items
            "AR/TangoARRender",
            "FX/Flare",
            "GUI/Text Shader",
            "Legacy Shaders/Bumped Diffuse",
            "Legacy Shaders/Bumped Specular",
            "Legacy Shaders/Decal",
            "Legacy Shaders/Diffuse Detail",
            "Legacy Shaders/Diffuse Fast",
            "Legacy Shaders/Diffuse",
            "Legacy Shaders/Lightmapped/Bumped Diffuse",
            "Legacy Shaders/Lightmapped/Bumped Specular",
            "Legacy Shaders/Lightmapped/Diffuse",
            "Legacy Shaders/Lightmapped/Specular",
            "Legacy Shaders/Lightmapped/VertexLit",
            "Legacy Shaders/Parallax Diffuse",
            "Legacy Shaders/Parallax Specular",
            "Legacy Shaders/Reflective/Bumped Diffuse",
            "Legacy Shaders/Reflective/Bumped Specular",
            "Legacy Shaders/Reflective/Bumped Unlit",
            "Legacy Shaders/Reflective/Bumped VertexLit",
            "Legacy Shaders/Reflective/Diffuse",
            "Legacy Shaders/Reflective/Parallax Diffuse",
            "Legacy Shaders/Reflective/Parallax Specular",
            "Legacy Shaders/Reflective/Specular",
            "Legacy Shaders/Reflective/VertexLit",
            "Legacy Shaders/Self-Illumin/Bumped Diffuse",
            "Legacy Shaders/Self-Illumin/Bumped Specular",
            "Legacy Shaders/Self-Illumin/Diffuse",
            "Legacy Shaders/Self-Illumin/Parallax Diffuse",
            "Legacy Shaders/Self-Illumin/Parallax Specular",
            "Legacy Shaders/Self-Illumin/Specular",
            "Legacy Shaders/Self-Illumin/VertexLit",
            "Legacy Shaders/Specular",
            "Legacy Shaders/Transparent/Bumped Diffuse",
            "Legacy Shaders/Transparent/Bumped Specular",
            "Legacy Shaders/Transparent/Cutout/Bumped Diffuse",
            "Legacy Shaders/Transparent/Cutout/Bumped Specular",
            "Legacy Shaders/Transparent/Cutout/Diffuse",
            "Legacy Shaders/Transparent/Cutout/Soft Edge Unlit",
            "Legacy Shaders/Transparent/Cutout/Specular",
            "Legacy Shaders/Transparent/Cutout/VertexLit",
            "Legacy Shaders/Transparent/Diffuse",
            "Legacy Shaders/Transparent/Parallax Diffuse",
            "Legacy Shaders/Transparent/Parallax Specular",
            "Legacy Shaders/Transparent/Specular",
            "Legacy Shaders/Transparent/VertexLit",
            "Legacy Shaders/VertexLit",
            "Mobile/Bumped Diffuse",
            "Mobile/Bumped Specular (1 Directional Light)",
            "Mobile/Bumped Specular",
            "Mobile/Diffuse",
            "Mobile/Particles/Additive",
            "Mobile/Particles/Alpha Blended",
            "Mobile/Particles/Multiply",
            "Mobile/Particles/VertexLit Blended",
            "Mobile/Skybox",
            "Mobile/Unlit (Supports Lightmap)",
            "Mobile/VertexLit (Only Directional Lights)",
            "Mobile/VertexLit",
            "Nature/SpeedTree Billboard",
            "Nature/SpeedTree",
            "Nature/Terrain/Diffuse",
            "Nature/Terrain/Specular",
            "Nature/Terrain/Standard",
            "Nature/Tree Creator Bark",
            "Nature/Tree Creator Leaves Fast",
            "Nature/Tree Creator Leaves",
            "Nature/Tree Soft Occlusion Bark",
            "Nature/Tree Soft Occlusion Leaves",
            "Particles/~Additive-Multiply",
            "Particles/Additive (Soft)",
            "Particles/Additive",
            "Particles/Alpha Blended Premultiply",
            "Particles/Alpha Blended",
            "Particles/Anim Alpha Blended",
            "Particles/Blend",
            "Particles/Multiply (Double)",
            "Particles/Multiply",
            "Particles/VertexLit Blended",
            "Skybox/6 Sided",
            "Skybox/Cubemap",
            "Skybox/Procedural",
            "Sprites/Default",
            "Sprites/Diffuse",
            "Sprites/Mask",
            "Standard (Roughness setup)",
            "Standard (Specular setup)",
            "Standard",
            "UI/Default Font",
            "UI/Default",
            "UI/DefaultETC1",
            "UI/Lit/Bumped",
            "UI/Lit/Detail",
            "UI/Lit/Refraction Detail",
            "UI/Lit/Refraction",
            "UI/Lit/Transparent",
            "UI/Unlit/Detail",
            "UI/Unlit/Text Detail",
            "UI/Unlit/Text",
            "UI/Unlit/Transparent",
            "Unlit/Color",
            "Unlit/Texture",
            "Unlit/Transparent Cutout",
            "Unlit/Transparent",
            "VR/SpatialMapping/Occlusion",
            "VR/SpatialMapping/Wireframe",
            #endregion
#elif UNITY_2017_1
            #region 2017.1.x : 104 items
            "FX/Flare",
            "GUI/Text Shader",
            "Legacy Shaders/Bumped Diffuse",
            "Legacy Shaders/Bumped Specular",
            "Legacy Shaders/Decal",
            "Legacy Shaders/Diffuse Detail",
            "Legacy Shaders/Diffuse Fast",
            "Legacy Shaders/Diffuse",
            "Legacy Shaders/Lightmapped/Bumped Diffuse",
            "Legacy Shaders/Lightmapped/Bumped Specular",
            "Legacy Shaders/Lightmapped/Diffuse",
            "Legacy Shaders/Lightmapped/Specular",
            "Legacy Shaders/Lightmapped/VertexLit",
            "Legacy Shaders/Parallax Diffuse",
            "Legacy Shaders/Parallax Specular",
            "Legacy Shaders/Reflective/Bumped Diffuse",
            "Legacy Shaders/Reflective/Bumped Specular",
            "Legacy Shaders/Reflective/Bumped Unlit",
            "Legacy Shaders/Reflective/Bumped VertexLit",
            "Legacy Shaders/Reflective/Diffuse",
            "Legacy Shaders/Reflective/Parallax Diffuse",
            "Legacy Shaders/Reflective/Parallax Specular",
            "Legacy Shaders/Reflective/Specular",
            "Legacy Shaders/Reflective/VertexLit",
            "Legacy Shaders/Self-Illumin/Bumped Diffuse",
            "Legacy Shaders/Self-Illumin/Bumped Specular",
            "Legacy Shaders/Self-Illumin/Diffuse",
            "Legacy Shaders/Self-Illumin/Parallax Diffuse",
            "Legacy Shaders/Self-Illumin/Parallax Specular",
            "Legacy Shaders/Self-Illumin/Specular",
            "Legacy Shaders/Self-Illumin/VertexLit",
            "Legacy Shaders/Specular",
            "Legacy Shaders/Transparent/Bumped Diffuse",
            "Legacy Shaders/Transparent/Bumped Specular",
            "Legacy Shaders/Transparent/Cutout/Bumped Diffuse",
            "Legacy Shaders/Transparent/Cutout/Bumped Specular",
            "Legacy Shaders/Transparent/Cutout/Diffuse",
            "Legacy Shaders/Transparent/Cutout/Soft Edge Unlit",
            "Legacy Shaders/Transparent/Cutout/Specular",
            "Legacy Shaders/Transparent/Cutout/VertexLit",
            "Legacy Shaders/Transparent/Diffuse",
            "Legacy Shaders/Transparent/Parallax Diffuse",
            "Legacy Shaders/Transparent/Parallax Specular",
            "Legacy Shaders/Transparent/Specular",
            "Legacy Shaders/Transparent/VertexLit",
            "Legacy Shaders/VertexLit",
            "Mobile/Bumped Diffuse",
            "Mobile/Bumped Specular (1 Directional Light)",
            "Mobile/Bumped Specular",
            "Mobile/Diffuse",
            "Mobile/Particles/Additive",
            "Mobile/Particles/Alpha Blended",
            "Mobile/Particles/Multiply",
            "Mobile/Particles/VertexLit Blended",
            "Mobile/Skybox",
            "Mobile/Unlit (Supports Lightmap)",
            "Mobile/VertexLit (Only Directional Lights)",
            "Mobile/VertexLit",
            "Nature/SpeedTree Billboard",
            "Nature/SpeedTree",
            "Nature/Terrain/Diffuse",
            "Nature/Terrain/Specular",
            "Nature/Terrain/Standard",
            "Nature/Tree Creator Bark",
            "Nature/Tree Creator Leaves Fast",
            "Nature/Tree Creator Leaves",
            "Nature/Tree Soft Occlusion Bark",
            "Nature/Tree Soft Occlusion Leaves",
            "Particles/~Additive-Multiply",
            "Particles/Additive (Soft)",
            "Particles/Additive",
            "Particles/Alpha Blended Premultiply",
            "Particles/Alpha Blended",
            "Particles/Anim Alpha Blended",
            "Particles/Blend",
            "Particles/Multiply (Double)",
            "Particles/Multiply",
            "Particles/VertexLit Blended",
            "Skybox/6 Sided",
            "Skybox/Cubemap",
            "Skybox/Procedural",
            "Sprites/Default",
            "Sprites/Diffuse",
            "Sprites/Mask",
            "Standard (Specular setup)",
            "Standard",
            "UI/Default Font",
            "UI/Default",
            "UI/DefaultETC1",
            "UI/Lit/Bumped",
            "UI/Lit/Detail",
            "UI/Lit/Refraction Detail",
            "UI/Lit/Refraction",
            "UI/Lit/Transparent",
            "UI/Unlit/Detail",
            "UI/Unlit/Text Detail",
            "UI/Unlit/Text",
            "UI/Unlit/Transparent",
            "Unlit/Color",
            "Unlit/Texture",
            "Unlit/Transparent Cutout",
            "Unlit/Transparent",
            "VR/SpatialMapping/Occlusion",
            "VR/SpatialMapping/Wireframe",
            #endregion
#endif
        };

        public string Generate()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Constants.Tab + @"public static class ShaderNames");
            builder.AppendLine(Constants.Tab + @"{");
            foreach (var item in Get())
            {
                builder.AppendLine(Constants.Tab + Constants.Tab + item);
            }
            builder.AppendLine(Constants.Tab + @"}");

            return builder.ToString();
        }

        private static string[] Get()
        {
            var shaders = GetDefaultShaders()
                .Concat(Search())
                .Select(x => new BuildSetting(x))
                .Select(x => x.GenerateCSharpSentence())
                .ToArray();
            return shaders;
        }

        private static string[] GetDefaultShaders()
        {
            return buildinShaders;
        }

        private static string[] Search()
        {
            // Search all folders except editor.
            var items = Directory.GetFiles(Application.dataPath, "*", SearchOption.AllDirectories)
                .SelectMany(x => new DirectoryInfo(x).GetFiles())
                .Where(x => !(x.Directory.FullName.Contains("editor") || x.Directory.FullName.Contains("Editor")))
                .Where(x => x.Extension == ".shader")
                .SelectMany(x => File.ReadAllLines(x.FullName))
                .Where(x => x.Contains("Shader \""))
                .Select(x => x.Replace("Shader \"", ""))
                .Select(x => x.Replace("\" {", ""))
                .Where(x => !x.StartsWith("Hidden"))
                .OrderBy(x => x)
                .ToArray();
            return items;
        }

        private struct BuildSetting
        {
            public string Name { get; set; }
            public string CSharpName { get; set; }
            public BuildSetting(string name)
            {
                Name = name;
                var validCharacterName = InvalidCharacterPairs.Replace(name);
                var validKeyword = InvalidNames.Replace(validCharacterName);
                CSharpName = validKeyword;
            }

            public string GenerateCSharpSentence()
            {
                return "public static string " + CSharpName + " { get {return \"" + Name + "\";} }";
            }
        }
    }
}
#endif
