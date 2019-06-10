using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BetterRepository.BetterRepositories
{
    internal static class TypeExtensions
    {
        internal static Type GetElementTypeForExpression(this Type seqType)
        {
            var enumerableType = FindIEnumerableType(seqType);
            return enumerableType == null ? seqType : enumerableType.GetGenericArguments()[0];
        }
        internal static MethodInfo GetGenericMethod(this Type owner, string methodName)
        {
            return owner.GetMethods().SingleOrDefault(m => m.Name == methodName && m.IsGenericMethod);
        }
        private static Type FindIEnumerableType(Type seqType)
        {
            if (seqType == null || seqType == typeof(string))
                return null;

            if (seqType.IsArray)
                return typeof(IEnumerable<>).MakeGenericType(seqType.GetElementType());

            if (seqType.IsGenericType)
            {
                foreach (Type arg in seqType.GetGenericArguments())
                {
                    Type ienum = typeof(IEnumerable<>).MakeGenericType(arg);
                    if (ienum.IsAssignableFrom(seqType))
                    {
                        return ienum;
                    }
                }
            }

            var ifaces = seqType.GetInterfaces();
            if (ifaces?.Length > 0)
            {
                foreach (Type iface in ifaces)
                {
                    Type ienum = FindIEnumerableType(iface);
                    if (ienum != null)
                    {
                        return ienum;
                    }
                }
            }

            if (seqType?.BaseType != typeof(object))
            {
                return FindIEnumerableType(seqType.BaseType);
            }

            return null;
        }
    }
}
