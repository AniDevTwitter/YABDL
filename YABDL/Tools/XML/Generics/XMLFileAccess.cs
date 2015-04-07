using System;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using System.IO;
using YABDL.Tools.Extenstions;

namespace YABDL.Tools.XML.Generics
{
    public class XMLFileAccess<T> where T : class, new()
    {
        // Analysis disable once StaticFieldInGenericType
        private static readonly XmlWriterSettings settings = new XmlWriterSettings()
            {
#if DEBUG
                Indent = true,
#else
                Indent = false,
#endif
                IndentChars = "\t",
                NewLineChars = "\r\n",
#if DEBUG
                NewLineOnAttributes = true,
#else
                NewLineOnAttributes = false,
#endif
            };

        private readonly string xmlFilePath;

        public XMLFileAccess(string xmlFilePath)
        {
            this.xmlFilePath = xmlFilePath;
        }

        public void Write(T item, bool createFolderIfNecessary = true)
        {
            try
            {
                if(createFolderIfNecessary)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(this.xmlFilePath));
                }
                using (var writer = XmlWriter.Create(this.xmlFilePath, XMLFileAccess<T>.settings))
                {
                    new XmlSerializer(typeof(T)).Serialize(writer, item);
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(@"Can't write " + item.ToString() + @" of type + " + typeof(T).ToString() + @" into file " + this.xmlFilePath + @"exception : " + e.ToString());
                throw;
            }
        }

        public T Read()
        {
            try
            {
                using (var writer = XmlReader.Create(this.xmlFilePath))
                {
                    return (T)new XmlSerializer(typeof(T)).Deserialize(writer);
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(@"Can't read type " + typeof(T).ToString() + @"into file " + this.xmlFilePath + @"exception : " + e.ToString());
                throw;
            }
        }

        public bool Exists()
        {
            return File.Exists(this.xmlFilePath);
        }
    }

    public static class XMLFileAccess
    {
        public static T Read<T>(string xmlFilePath) where T : class, new()
        {
            return new XMLFileAccess<T>(xmlFilePath).Read();
        }

        public static void Write<T>(T obj, string xmlFilePath) where T : class, new()
        {
            new XMLFileAccess<T>(xmlFilePath.ThrowIfNull()).Write(obj.ThrowIfNull());
        }
    }
}

