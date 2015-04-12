using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;

namespace YABDL.Models.APIs
{
    [Serializable]
    public class DanbooruBasicType<T> : IXmlSerializable
    {
        private const string NilAttributeName = "nil";
        private const string TypeAttributeName = "type";

        public DanbooruBasicType()
        {

        }

        [XmlIgnore]
        public T Value
        {
            get;
            set;
        }

        #region IXmlSerializable implementation

        public XmlSchema GetSchema()
        {
            return null;
        }

        private void SetValue(object value)
        {
            var field = this.GetType().GetField("val");
            field.SetValue(this, value);
        }

        public void ReadXml(XmlReader reader)
        {
            var typeOfT = typeof(T);
            var nilValue = reader.GetAttribute(NilAttributeName); // TODO : Move this into a confile
            var typeValue = reader.GetAttribute(TypeAttributeName); // TODO : Move this into a confile
            if (!string.IsNullOrEmpty(nilValue))
            {
                if (nilValue == "true")
                {
                    // TODO : Just check if T match a nullable / reference type, default value will be null anyway
                }
            }
            else if (!string.IsNullOrEmpty(typeValue))
            {
                var danbooruType = this.GeTypeFromDanbooruString(typeValue);
                if (typeof(T) != danbooruType)
                {
                    throw new InvalidCastException("Generic vs serialized type mismatch, expected : " + typeof(T) + " got : " + danbooruType);
                }
                this.SetValue(reader.ReadContentAs(danbooruType, null));
            }
            else // If nothing found fallback to string serialization and pray
            {
                if (typeOfT != typeof(string))
                {
                    throw new InvalidCastException("Generic vs serialized type mismatch, expected : " + typeof(DateTime) + " got : " + typeValue);
                }
                this.SetValue(reader.ReadContentAsString());
            }

        }

        private Type GeTypeFromDanbooruString(string str)
        {
            switch (str)
            {
                case "string":  // TODO : Move this into a confile
                    return typeof(string);

                case "datetime": // TODO : Move this into a confile
                    return typeof(DateTime);

                case "integer": // TODO : Move this into a confile
                    return typeof(int);
                
                case "boolean": // TODO : Move this into a confiles
                    return typeof(bool);

                default:
                    throw new NotSupportedException("Following type isn't supported : " + str);
            }
        }

        private string GetDanbooruTypeString(Type type)
        {
            if (type == typeof(bool))
            {
                return "boolean";
            }
            if (type == typeof(DateTime))
            {
                return "datetime";
            }
            if (type == typeof(int))
            {
                return "integer";
            }
            if (type == typeof(string))
            {
                return null;
            }
            throw new NotSupportedException("Following type isn't supported : " + type);
        }

        public void WriteXml(XmlWriter writer)
        {
            var type = this.GetDanbooruTypeString(typeof(T));

            if (object.ReferenceEquals(this.Value, null))
            {
                writer.WriteAttributeString(NilAttributeName, "true");
            }
            if (!string.IsNullOrEmpty(type))
            {
                writer.WriteAttributeString(TypeAttributeName, type);
            }
            else
            {
                writer.WriteCData(this.Value.ToString()); // This won't work obviously
            }
        }

        #endregion
    }
}
