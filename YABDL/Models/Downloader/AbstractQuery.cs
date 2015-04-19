using System;
using YABDL.Models.Interfaces;
using System.Collections.Generic;
using YABDL.Models.API.Interfaces;
using System.Linq;
using System.IO;

namespace YABDL.Models.Downloader
{
    public abstract class AbstractQuery : IQuery
    {
        private object locker;


        protected AbstractQuery()
        {
            this.locker = new object();

        }

        public abstract IList<Tuple<string, string>> ToDownload {get; set;}

        #region IQuery implementation

        public abstract IList<Guid> Providers { get; set; }
        public abstract string Tags {get; set;}
        public abstract string FolderPath {get; set; }

        public void Execute(IAPIAccess access, IReadOnlyDictionary<Guid, IProvider> idToProvider)
        {
            lock (locker)
            {
                if (this.ToDownload == null)
                {
                    // Avoid Random changes leading to break the loop
                    var tags = this.Tags;
                    // parrallel is stupid here as cpu isn't the bottleneck
                    this.ToDownload = this.Providers.ToList().AsParallel().SelectMany(x => this.GetPostsLinks(access, idToProvider[x], tags)).ToList();
                }
                var folderPath = this.FolderPath;
                this.ToDownload.AsParallel().ForAll(x => this.DownloadAndWriteToDisk(Path.Combine(folderPath, x.Item1), x.Item2));
            }
        }

        #endregion

        private void DownloadAndWriteToDisk(string filepath, string url)
        {
            // todo
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

