using System;
using Gtk;
using System.Linq;
using MoreLinq;

namespace YABDL.Views.Filters
{
    public partial class FiltersView
    {

        private void BuildVisuals()
        {
            var nameRenderer = new CellRendererText();
            nameRenderer.Editable = true;
            nameRenderer.Edited += (o, args) =>
            {
                    ((ProviderViewModel)(this.NodeStore.GetNode(new TreePath(args.Path)))).Name = args.NewText;
            };
            var urlRenderer = new CellRendererText();
            urlRenderer.Editable = true;
            urlRenderer.Edited += (o, args) =>
                {
                    ((ProviderViewModel)(this.NodeStore.GetNode(new TreePath(args.Path)))).Url = args.NewText;
                };
            this.SetupColumn(this.AppendColumn("Name", nameRenderer, "text", 0));
            this.SetupColumn(this.AppendColumn("Url", urlRenderer, "text", 1));
            this.providers.Values.ForEach(x => this.NodeStore.AddNode(x));

        }

        private void SetupColumn(TreeViewColumn column)
        {
            column.Resizable = true;
            column.Reorderable = true; // Todo add support
        }
    }
}

