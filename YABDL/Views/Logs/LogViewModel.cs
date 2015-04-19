using System;
using Gtk;

namespace YABDL.Views.Logs
{
    public class LogViewModel : TreeNode
    {
        private readonly LogType type;
        private readonly string origin;
        private readonly string message;


        public LogViewModel(LogType type, string origin, string message)
        {
            this.type = type;
            this.origin = origin;
            this.message = message;
        }


        // TODO : Add support (aka make a custom cell rendererer to display somekind of icon for this)
        public LogType Type
        {
            get
            {
                return this.type;
            }
        }

        [TreeNodeValue(Column=0)]
        public string Origin
        {
            get
            {
                return this.origin;
            }
        }

        [TreeNodeValue(Column=1)]
        public string Message
        {
            get
            {
                return this.message;
            }
        }
    }
}

