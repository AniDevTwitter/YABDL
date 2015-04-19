using System;
using Gtk;
using YABDL.Views.Filters;
using YABDL.Views.Logs;

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

            this.filters = new FiltersView(this.conf.Providers);


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
            this.logs = new LogsView();
            this.details.AppendPage(this.logs, new Label("Logs"));
        }

        private void SetupToolbar()
        {
            this.toolbar = new Toolbar();
            this.toolbar.ToolbarStyle = ToolbarStyle.Icons;
            var addButton = new ToolButton(Stock.Add); 
            var saveButton = new ToolButton(Stock.Save);
            this.toolbar.Insert(addButton, this.toolbar.NItems);
            this.toolbar.Insert(saveButton, this.toolbar.NItems);

            saveButton.Clicked += (sender, e) => this.conf.Sync();
            addButton.Clicked += (sender, e) => Console.WriteLine("Added something (or not)");
        }
    }
}

