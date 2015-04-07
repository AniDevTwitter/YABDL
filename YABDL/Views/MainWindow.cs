using System;
using Gtk;
using YABDL.Models.Interfaces;
using YABDL.Models;


namespace YABDL.Views
{
    public class MainWindow : Window
    {
        private readonly IGlobalConf conf;
        public MainWindow() : base(WindowType.Toplevel)
        {
            this.conf = GlobalConf.GetGlobalConf();
            this.Title = this.conf.AppTitle;
        }
    }
}

