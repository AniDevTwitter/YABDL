using System;
using Gtk;

namespace YABDL.Views
{
    public sealed partial class MainWindow : Gtk.Window
    {
        public MainWindow()
            : base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }


        protected override bool OnDeleteEvent(Gdk.Event evnt)
        {
            Application.Quit();
            return base.OnDeleteEvent(evnt);
        }
    }
}

