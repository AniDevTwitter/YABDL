using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace YABDL.Models.APIs
{
    [XmlRoot("posts")]
    public class DanbooruPosts
    {
        [XmlElement("post")]
        public List<DanbooruPost> Posts{ get; set;}
    }
}

