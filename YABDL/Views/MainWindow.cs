using System;
using Gtk;
using YABDL.Models.Interfaces;
using YABDL.Models;


namespace YABDL.Views
{
    public class MainWindow : Window
    {
        private readonly IGlobalConf conf;
        //private readonly HPaned layout;

        public MainWindow() : base(WindowType.Toplevel)
        {
            this.conf = GlobalConf.GetGlobalConf();
            this.Title = this.conf.AppTitle;
            //this.layout = new HPaned();
        
        }

        protected override bool OnDeleteEvent(Gdk.Event evnt)
        {
            Application.Quit();
            return base.OnDeleteEvent(evnt);
        }
    }
}

