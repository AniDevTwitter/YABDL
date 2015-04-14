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
            this.Value = default(T);
        }

        public DanbooruBasicType(T value)
        {
            this.Value = value;
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
            var prop = this.GetType().GetProperty("Value");
            prop.SetValue(this, value);
        }

        private object GetValue()
        {
            var prop = this.GetType().GetProperty("Value");
            return prop.GetValue(this);
            
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
                this.SetValue(reader.ReadElementContentAs(danbooruType, null));
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

        private Type GeTypeFromDanbooruString(string strType)
        {
            switch (strType)
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
                    throw new NotSupportedException("Following type isn't supported : " + strType);
            }
        }

        private string GetDanbooruTypeString(Type type)
        {
            type = Nullable.GetUnderlyingType(type) ?? type;
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

        private string ValueToXmlString()
        {
            var type = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
            if (type == typeof(bool))
            {
                return XmlConvert.ToString((bool)this.GetValue());
            }
            if (type == typeof(DateTime))
            {
                return XmlConvert.ToString((DateTime)this.GetValue(), XmlDateTimeSerializationMode.Utc); // UTC because... well abritrary
            }
            if (type == typeof(int))
            {
                return XmlConvert.ToString((int)this.GetValue());
            }
            if (type == typeof(string))
            {
                return (string)this.GetValue();
            }
            throw new NotSupportedException("Following type isn't supported : " + type);
        }

        public void WriteXml(XmlWriter writer)
        {
            var type = this.GetDanbooruTypeString(typeof(T));
            if (!string.IsNullOrEmpty(type))
            {
                writer.WriteAttributeString(TypeAttributeName, type);
            }
            if (object.ReferenceEquals(this.Value, null))
            {
                writer.WriteAttributeString(NilAttributeName, "true");
            }
            else
            {
                writer.WriteString(this.ValueToXmlString()); // This won't work obviously
            }
        }

        #endregion

    }
}
