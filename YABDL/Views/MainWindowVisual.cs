using System;
using Gtk;
using YABDL.Views.Filters;
using YABDL.Views.Logs;

namespace YABDL.Views
{
    public partial class MainWindow
    {
        // Layouts
        private VPaned mainLayout;
        private HPaned topLayout;
        private VBox toolbarMainLayout;
        private Toolbar toolbar;
        private Notebook details;

        // SubViews
        private FiltersView filters;
        private LogsView logs;


        private void BuildVisual()
        {
            this.toolbarMainLayout = new VBox(false, 2);
            this.mainLayout = new VPaned();
            this.topLayout = new HPaned();

            this.filters = new FiltersView(this.conf.Providers);


            this.SetupToolbar();
            this.SetupDetails();

            this.mainLayout.Add1(this.topLayout);
            this.mainLayout.Add2(this.details);
            this.topLayout.Add1(this.filters);
            this.topLayout.Add2(new Label("HUURRR"));
            this.toolbarMainLayout.PackStart(this.toolbar, false, false, 0);
            this.toolbarMainLayout.PackStart(this.mainLayout, true, true, 0);


            this.Add(this.toolbarMainLayout);

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

