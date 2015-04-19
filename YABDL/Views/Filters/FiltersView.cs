using System;
using Gtk;
using YABDL.Models.Interfaces;
using System.Collections;
using System.Collections.Generic;
using YABDL.Tools.Extensions;
using System.Linq;

namespace YABDL.Views.Filters
{
    public partial class FiltersView : NodeView
    {
        private readonly IDictionary<IProvider, ProviderViewModel> providers;

        public FiltersView(IList<IProvider> providers) : base(new NodeStore(typeof(ProviderViewModel)))
        {
            this.providers = providers.ThrowIfNull().ToDictionary(x => x, x => new ProviderViewModel(x));
            this.BuildVisuals();
        }

        public void AddProvider(IProvider provider)
        {
            var node = new ProviderViewModel(provider);
            this.providers.Add(provider, node);
            this.NodeStore.AddNode(node);
        }

        public void RemoveProvider(IProvider provider)
        {
            var node = this.providers[provider];
            this.providers.Remove(provider);
            this.NodeStore.RemoveNode(node);
        }
    }
}

