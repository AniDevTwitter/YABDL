using Gtk;
using YABDL.Views.ViewModels;
using System.Collections.ObjectModel;
using YABDL.Views.ViewModels.Common;

namespace YABDL.Views.Filters
{
    public partial class FiltersView : NodeView
    {
        public FiltersView(ObservableCollection<ProviderViewModel> providers) : base(new BoundedNodeStore<ProviderViewModel>(providers))
        {
            this.BuildVisuals();
        }
            
    }
}

