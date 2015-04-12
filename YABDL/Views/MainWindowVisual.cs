using System;
using Gtk;

namespace YABDL.Views
{
    public partial class MainWindow
    {
        private HPaned layout;

        public void BuildVisual()
        {
            this.layout = new HPaned();
        }
    }
}

