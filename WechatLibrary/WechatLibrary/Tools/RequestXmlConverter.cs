using System;
using System.Linq;
using System.Xml.Linq;

namespace WechatLibrary.Tools
{
    internal class RequestXmlConverter
    {
        /// <summary>
        /// 反序列化 xml 到指定的类。
        /// </summary>
        /// <param name="xd">xml。</param>
        /// <param name="type">类。</param>
        /// <returns>类的实例。</returns>
        internal static object Deserialize(XDocument xd, Type type)
        {
            if (xd == null)
            {
                throw new ArgumentNullException("");
            }

            if (type == null)
            {
                throw new ArgumentNullException("");
            }

            var instance = Activator.CreateInstance(type);

            var root = xd.Root;

            foreach (var field in type.GetFields().AsParallel())
            {
                string fieldName = field.Name;
                XElement fieldElement = root.Element(fieldName);

                if (fieldElement != null)
                {
                    field.SetValue(instance, Convert.ChangeType(fieldElement.Value, field.FieldType));
                }
            }

            foreach (var property in type.GetProperties().AsParallel())
            {
                string propertyName = property.Name;
                XElement propertyElement = root.Element(propertyName);

                if (propertyElement != null)
                {
                    property.SetValue(instance, Convert.ChangeType(propertyElement.Value, property.PropertyType), null);
                }
            }

            return instance;
        }

        /// <summary>
        /// 反序列化 xml 到指定的类。
        /// </summary>
        /// <typeparam name="T">类。</typeparam>
        /// <param name="xd">xml。</param>
        /// <returns>类的实例。</returns>
        internal static T Deserialize<T>(XDocument xd)
        {
            return (T)Deserialize(xd, typeof(T));
        }
    }
}
