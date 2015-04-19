using System;
using Gtk;
using YABDL.Models.Interfaces;
using YABDL.Tools.Extensions;

namespace YABDL.Views.Filters
{
    [TreeNode(ListOnly=true)]
    public class ProviderViewModel : TreeNode
    {
        private readonly IProvider provider;

        public ProviderViewModel(IProvider provider)
        {
            this.provider = provider.ThrowIfNull();
        }

        [TreeNodeValue(Column=0)]
        public string Name
        {
            get
            {
                return this.provider.Name;
            }
            set
            {
                this.provider.Name = value;
            }
        }

        [TreeNodeValue(Column=1)]
        public string Url
        {
            get
            {
                return this.provider.Url;
            }
            set
            {
                this.provider.Url = value;
            }
        }
    }
}

