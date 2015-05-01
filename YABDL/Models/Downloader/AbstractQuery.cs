using System;
using YABDL.Models.Interfaces;
using System.Collections.Generic;
using YABDL.Models.API.Interfaces;
using System.Linq;
using System.IO;
using System.Xml.Serialization;

namespace YABDL.Models.Downloader
{
    public abstract class AbstractQuery : IQuery
    {
        private object locker;


        protected AbstractQuery()
        {
            this.locker = new object();

        }
          
        #region IQuery implementation

        public abstract List<Guid> Providers { get; set; }
        public abstract string Tags {get; set;}
        public abstract string FolderPath {get; set; }
        public abstract string Label { get; set; }

        public void Execute(IAPIAccess access, IReadOnlyDictionary<Guid, IProvider> idToProvider)
        {
            lock (locker)
            {

                // Avoid Random changes leading to break the loop
                var tags = this.Tags;
                // parrallel is stupid here as cpu isn't the bottleneck
                var toDownload = this.Providers.ToList().SelectMany(x => this.GetPostsLinks(access, idToProvider[x], tags)).ToList();

                var folderPath = this.FolderPath;
                Directory.CreateDirectory(folderPath); // Just in case
                toDownload.ForEach(x => this.DownloadAndWriteToDisk(Path.Combine(folderPath, x.Item1), x.Item2));
            }
        }

        #endregion

        private void DownloadAndWriteToDisk(string filepath, string url)
        {
            // todo

            using (var file = File.Create(filepath))
            {

            }
        }

        private IEnumerable<Tuple<string, string>> GetPostsLinks(IAPIAccess access, IProvider provider, string tags)
        {
            var i = 1;
            var response = access.Posts.List(provider, i, 100, tags);
            while (!response.Success && response.Data.Posts.Count > 0)
            {
                foreach (var post in response.Data.Posts)
                {
                    yield return Tuple.Create(post.Id + "." + post.FileExt, provider.Url + post.FileUrl);
                }
                i++;
                response = access.Posts.List(provider, i, 100, tags);
            }
        }
    }
}

