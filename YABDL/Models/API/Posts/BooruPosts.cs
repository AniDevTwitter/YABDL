using System;
using System.Collections.Generic;
using YABDL.Models.API.Interfaces;
using System.IO;
using YABDL.Models.Interfaces;
using YABDL.Tools.Extensions;
using System.Xml.Linq;
using System.Linq;
using MoreLinq;

namespace YABDL.Models.API.Posts
{
    public class BooruPosts : IAPIDataObject<IProviderPost>
    {
        public List<BooruPost> Posts{ get; set;}

        #region IAPIDataObject implementation

        public void DeserializeFromXML(Stream xml, IProviderPost metas)
        {
            var document = xml.ToXDocument();
            this.Posts = document.Root.Descendants(metas.Post).Select(x => 
                {
                    var ret = new BooruPost();
                    ret.DeserializeFromXML(x, metas);
                    return ret;
                }).ToList();
        }
           

        public Stream SerializeToXML(IProviderPost restMetatadatasProvider)
        {
            // TODO : Handle serialize into xml, but not now since it's pointless
            throw new NotImplementedException();
        }
            
        #endregion
    }
}

