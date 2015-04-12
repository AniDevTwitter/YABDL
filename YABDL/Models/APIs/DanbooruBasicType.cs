using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;

namespace YABDL.Models.APIs
{
    [Serializable]
    public class DanbooruBasicType<T> : IXmlSerializable
    {
        private T val;
        public DanbooruBasicType()
        {

        }

        [XmlIgnore]
        public T Value
        {
            get
            {
                return this.val;
            }
            set
            {
                this.val = value;
            }
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
            var nilValue = reader.GetAttribute("nil"); // TODO : Move this into a confile
            var typeValue = reader.GetAttribute("type"); // TODO : Move this into a confile
            if (!string.IsNullOrEmpty(nilValue))
            {
                if (nilValue == "true")
                {
                    // TODO : Just check if T match a nullable / reference type, default value will be null anyway
                }
            }
            else if (!string.IsNullOrEmpty(typeValue))
            {
                switch (typeValue)
                {
                    case "string":  // TODO : Move this into a confile
                        if (typeOfT != typeof(string))
                        {
                            throw new InvalidCastException("Generic vs serialized type mismatch, expected : " + typeof(string) + " got : " + typeValue);
                        }
                        this.SetValue(reader.ReadContentAsString()); 
                        break;

                    case "datetime": // TODO : Move this into a confile
                        if (typeof(T) != typeof(DateTime))
                        {
                            throw new InvalidCastException("Generic vs serialized type mismatch, expected : " + typeof(DateTime) + " got : " + typeValue);
                        }
                        this.SetValue(reader.ReadContentAsDateTime());
                        break;
                    case "integer": // TODO : Move this into a confile
                        if (typeOfT != typeof(int))
                        {
                            throw new InvalidCastException("Generic vs serialized type mismatch, expected : " + typeof(int) + " got : " + typeValue);
                        }
                        this.SetValue(reader.ReadContentAsInt());
                        break;
                    case "boolean": // TODO : Move this into a confiles
                        if (typeOfT != typeof(bool))
                        {
                            throw new InvalidCastException("Generic vs serialized type mismatch, expected : " + typeof(bool) + " got : " + typeValue);
                        }
                        this.SetValue(reader.ReadContentAsInt());
                        break;
                    default:
                        throw new NotSupportedException("Following type isn't supported : " + typeValue + " expecting : " + typeof(T));
                }
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

        public void WriteXml(XmlWriter writer)
        {
            //todo
        }

        #endregion
    }
}

