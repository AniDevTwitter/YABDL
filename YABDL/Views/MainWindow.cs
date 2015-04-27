using System;
using Gtk;
using YABDL.Models.Interfaces;
using YABDL.Models;
using YABDL.Models.API.Interfaces;
using YABDL.Models.API.Posts;
using System.Collections.ObjectModel;
using YABDL.Views.ViewModels;
using System.Linq;


namespace YABDL.Views
{
    public partial class MainWindow : Window
    {
        private readonly IGlobalConf conf;
        private readonly IAPIAccess apiAccess;

        private readonly ObservableCollection<ProviderViewModel> providers;

        public MainWindow() : base(WindowType.Toplevel)
        {
            this.conf = GlobalConf.GetGlobalConf();
            this.apiAccess = GlobalConf.GetAPIAccess();
            this.providers = new ObservableCollection<ProviderViewModel>(this.conf.Providers.Select(x => new ProviderViewModel(x)));
            this.Title = this.conf.AppTitle;
            this.BuildVisual();
            this.ShowAll();
        }



        protected override bool OnDeleteEvent(Gdk.Event evnt)
        {
            Application.Quit();
            return base.OnDeleteEvent(evnt);
        }
    }
}

