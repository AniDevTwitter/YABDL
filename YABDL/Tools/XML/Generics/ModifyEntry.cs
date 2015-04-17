using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace YABDL.Tools.XML.Generics
{
    [Serializable]
    [XmlInclude(typeof(ModifyField))]
    public class ModifyEntry
    {
        [XmlElement("IdEntry")]
        public Guid IdEntry;

        [XmlArray("Modifiers"), XmlArrayItem(typeof(ModifyField), ElementName = "Modifier")]
        public List<ModifyField> Modifiers;

        public ModifyEntry()
        {
            this.Modifiers = new List<ModifyField>();
        }
    }
}

