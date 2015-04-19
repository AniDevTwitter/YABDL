using System;
using Gtk;

namespace YABDL.Views.Logs
{
    public partial class LogsView : NodeView
    {
        public LogsView() : base(new NodeStore(typeof(LogViewModel)))
        {
            this.BuildVisuals();
        }

        public void Add(LogType type, string origin, string message)
        {
            this.NodeStore.AddNode(new LogViewModel(type, origin, message));
        } 

    }
}

