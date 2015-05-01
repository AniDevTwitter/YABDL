using System;
using Gtk;
using YABDL.Views.ViewModels;
using YABDL.Views.ViewModels.Common;
using MoreLinq;
using YABDL.Views.Common;

namespace YABDL.Views.NewQuery
{
    public partial class NewQueryView
    {
        private void BuildVisuals(string defaultOutputFolderPath)
        {

            var layout = new HBox();
            layout.PackStart(new Label("Label"), false, false, 2); 
            var labelEntry = new Entry();
            layout.PackStart(labelEntry, true, true, 2); 
            layout.PackStart(new Label("Tags : "), false, false, 2); 
            var tagsEntry = new Entry();
            layout.PackStart(tagsEntry, true, true, 2); 
            layout.PackStart(new Label("Provider"), false, false, 2); 
            var providerEntry = this.ProviderCombobox();

            layout.PackStart(providerEntry, true, true, 2); 
            layout.PackStart(new Label("Output folder path"), false, false, 2); 
            var folderSelectionLayout = new HBox();
            var folderEntry = new Entry(defaultOutputFolderPath);
            folderSelectionLayout.PackStart(folderEntry, true, true, 2);
            var folderSelectionButton = new Button(AppIcons.Search);
            folderSelectionButton.Clicked += (sender, e) => 
                {
                    using(var dialog = new FileChooserDialog("Select output directory", this, FileChooserAction.CreateFolder,           
                        "Cancel",ResponseType.Cancel,
                        "Select",ResponseType.Accept))
                    {
                        dialog.SetCurrentFolder(folderEntry.Text);
                        if((ResponseType)(dialog.Run()) == ResponseType.Accept)
                        {
                            folderEntry.Text = dialog.Filename;
                        }
                        dialog.Destroy();
                    }
                };
            folderSelectionLayout.PackStart(folderSelectionButton, false, false, 2);
            layout.PackStart(folderSelectionLayout, true, true, 2); 

            this.Add(layout);
        }

        private ComboBox ProviderCombobox()
        {
            var store = new ListStore(typeof(string), typeof(string));
            var retVal = new ComboBox(store);
            this.providers.ForEach(x => store.AppendValues(x.Name, x.Url));
            return retVal;
        }
    }
}

