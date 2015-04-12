using System;
using Gtk;
using YABDL.Models.Interfaces;
using YABDL.Models;


namespace YABDL.Views
{
    public partial class MainWindow : Window
    {
        private readonly IGlobalConf conf;
        private readonly IAPIAccess apiAccess;

        public MainWindow() : base(WindowType.Toplevel)
        {
            this.conf = GlobalConf.GetGlobalConf();
            this.apiAccess = GlobalConf.GetAPIAccess();
            var res = this.apiAccess.Posts.List(this.conf.Providers[0]);
            res.RunSynchronously(); // error in xml document, this is bad fix this asap
            var dbg = res.Result;
            this.Title = this.conf.AppTitle;
            this.BuildVisual();
        }



        protected override bool OnDeleteEvent(Gdk.Event evnt)
        {
            Application.Quit();
            return base.OnDeleteEvent(evnt);
        }
    }
}

