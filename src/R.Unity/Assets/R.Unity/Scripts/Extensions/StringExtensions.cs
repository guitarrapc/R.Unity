using System.Collections.Generic;
using System.Linq;
using System.Text;

#if UNITY_EDITOR
namespace RUnity.Generator.Extensions
{
    public static class StringExtensions
    {
        public static string ToJoinedString<T>(this IEnumerable<T> source)
        {
            return source.ToJoinedString("");
        }

        public static string ToJoinedString<T>(this IEnumerable<T> source, string separator)
        {
            var index = 0;
            return source.Aggregate(new StringBuilder(),
                    (sb, o) => (index++ == 0) ? sb.Append(o) : sb.AppendFormat("{0}{1}", separator, o))
                .ToString();
        }
    }
}
#endif
