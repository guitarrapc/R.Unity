#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
namespace RUnity.Generator
{
    public static class Constants
    {
        public static string Tab { get { return "    "; } }
        public static string DoubleTab { get { return Tab + Tab; } }
        public static string TripleTab { get { return DoubleTab + Tab; } }
    }
}
#endif
