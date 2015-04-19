using System;
using Gtk;

namespace YABDL.Views.Logs
{
    public partial class LogsView
    {
        public void BuildVisuals()
        {
            var nameRenderer = new CellRendererText();
            var urlRenderer = new CellRendererText();
            this.SetupColumn(this.AppendColumn("Origin", nameRenderer, "text", 0));
            this.SetupColumn(this.AppendColumn("Message", urlRenderer, "text", 1));
        }

        private void SetupColumn(TreeViewColumn column)
        {
            column.Resizable = true;
            column.Reorderable = true; // Todo add support
        }
    }
}

