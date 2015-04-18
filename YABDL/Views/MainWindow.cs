using System;
using Gtk;
using YABDL.Models.Interfaces;
using YABDL.Models;
using YABDL.Models.API.Interfaces;
using YABDL.Models.API.Posts;


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
            // DEBUG
            var dbg = (BooruPostsAccess)apiAccess.Posts;
            var dbg1 = dbg.ShowUnwrapped(this.conf.Providers[0], 1);

            //DEBUG
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

