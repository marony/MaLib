using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaLib
{
    public static class Util
    {
        private const int INDENT = 2;

        private static string _Dump(object o, int indent)
        {
            if (o == null)
                return "null";
            if (indent > 3)
                return "...";

            var type = o.GetType();
            var sb = new StringBuilder();
            sb.Append($"[");
            sb.Append(type.Name);
            sb.AppendLine($"]");
            foreach (var f in type.GetFields())
            {
                var name = f.Name;
                var value = f.GetValue(o);
                if (indent > 0)
                    sb.Append(new string(' ', indent * INDENT));
                sb.Append(name);
                sb.Append(" = ");
                if (!_IsPrimitive(f.FieldType) && !f.FieldType.IsArray && !f.FieldType.IsEnum)
                    value = _Dump(value, indent + 1);
                sb.Append(value);
                sb.AppendLine("");
            }
            foreach (var p in type.GetProperties())
            {
                if (!p.CanRead)
                    continue;
                var name = p.Name;
                var value = p.GetValue(o);
                if (indent > 0)
                    sb.Append(new string(' ', indent * INDENT));
                sb.Append(name);
                sb.Append(" = ");
                if (!_IsPrimitive(p.PropertyType) && !p.PropertyType.IsArray && !p.PropertyType.IsEnum)
                    value = _Dump(value, indent + 1);
                sb.Append(value);
                if (indent == 0)
                    sb.AppendLine("");
            }
            return sb.ToString();
        }

        private static bool _IsPrimitive(Type type)
        {
            return (type.IsPrimitive ||
                    type == typeof(string) ||
                    type == typeof(decimal));
        }

        /// <summary>
        /// プロパティやフィールドを読み取り文字列に変換する
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string Dump(object o)
        {
            return _Dump(o, 0);
        }
    }
}
