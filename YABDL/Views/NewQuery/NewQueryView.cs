using Gtk;
using YABDL.Views.ViewModels;
using System.Collections.ObjectModel;
using YABDL.Tools.Extensions;

namespace YABDL.Views.NewQuery
{
    public delegate void NewQueryHandler(object sender, NewQueryEventArgs ev);

    public partial class NewQueryView : Window
    {
        private readonly ObservableCollection<ProviderViewModel> providers;
        public NewQueryView(ObservableCollection<ProviderViewModel> providers, string defaultOutputFolderPath) : base("Create a new query")
        {
            this.providers = providers.ThrowIfNull();
            this.BuildVisuals(defaultOutputFolderPath);
            this.Resizable = false;
        }

        public event NewQueryHandler NewQuery;

    }
}

