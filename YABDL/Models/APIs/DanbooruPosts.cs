using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace YABDL.Models.APIs
{
    [XmlRoot("posts")]
    public class DanbooruPosts
    {
        //[XmlArray("Modifiers"), XmlArrayItem(typeof(ModifyField), ElementName = "Modifier")]
        [XmlElement("post")]
        public DanbooruPost[] Posts{ get; set;}
    }
}

