using System;
using Gtk;
using YABDL.Views.Filters;
using YABDL.Views.Logs;
using YABDL.Views.NewQuery;
using YABDL.Views.Common;

namespace YABDL.Views
{
    public partial class MainWindow
    {
        // Layouts
        private Toolbar toolbar;
        private Notebook details;

        // SubViews
        private FiltersView filters;
        private LogsView logs;


        private void BuildVisual()
        {
            var toolbarMainLayout = new VBox(false, 2);
            var mainLayout = new VPaned();
            var topLayout = new HPaned();

            this.filters = new FiltersView(this.providers);


            this.SetupToolbar();
            this.SetupDetails();

            mainLayout.Add1(topLayout);
            mainLayout.Add2(this.details);
            topLayout.Add1(this.filters);
            topLayout.Add2(new Label("HUURRR"));
            toolbarMainLayout.PackStart(this.toolbar, false, false, 0);
            toolbarMainLayout.PackStart(mainLayout, true, true, 0);


            this.Add(toolbarMainLayout);

        }

        private void SetupDetails()
        {
            this.details = new Notebook();
            this.details.TabPos = PositionType.Bottom;
            this.logs = new LogsView();
            this.details.AppendPage(this.logs, new Label("Logs"));
        }

        private void SetupToolbar()
        {
            this.toolbar = new Toolbar();
            this.toolbar.ToolbarStyle = ToolbarStyle.Icons;
            var addButton = new ToolButton(AppIcons.Add, null); 
            var saveButton = new ToolButton(AppIcons.Save, null);
            this.toolbar.Insert(addButton, this.toolbar.NItems);
            this.toolbar.Insert(saveButton, this.toolbar.NItems);

            saveButton.Clicked += (sender, e) => this.conf.Sync();
            addButton.Clicked += (sender, e) => 
                {
                    var newQuery = new NewQueryView(this.providers, this.conf.DefaultOutputFolderPath);
                    newQuery.NewQuery += this.OnNewQuery;
                    newQuery.ShowAll();
                };
        }

        private void OnNewQuery(object sender, NewQueryEventArgs ev)
        {
            this.conf.Queries.Add(ev.AsQuery(this.conf.Factory));
        }
    }
}

