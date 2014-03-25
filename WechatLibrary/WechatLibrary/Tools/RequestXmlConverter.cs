using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Xml.Linq;
using WechatLibrary.Request;

namespace WechatLibrary.Tools
{
    internal class RequestXmlConverter
    {
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

        internal static T Deserialize<T>(XDocument xd)
        {
            return (T)Deserialize(xd, typeof(T));
        }
    }
}
