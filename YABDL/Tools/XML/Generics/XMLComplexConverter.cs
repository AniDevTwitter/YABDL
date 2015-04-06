using System;
using System.IO;
using System.Xml.Serialization;

namespace YABDL.Tools.XML.Generics
{
    public static class XMLComplexConverter<T>
    {
        public const string FromXMLStringLitteral = "FromXMLString";
        public const string ToXMLStringLitteral = "ToXMLString";

        public static object FromXMLString(string str)
        {
            using (var reader = new StringReader(str))
            {
                return new XmlSerializer(typeof(T)).Deserialize(reader);
            }
        }

        public static string ToXMLString(object obj)
        {
            using (var writer = new StringWriter())
            {
                new XmlSerializer(typeof(T)).Serialize(writer, obj);
                return writer.ToString();
            }
        }
    }
}
