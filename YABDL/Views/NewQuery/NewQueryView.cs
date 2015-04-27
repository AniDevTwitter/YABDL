using System;
using Gtk;
using YABDL.Models.Interfaces;
using System.Collections.Generic;

namespace YABDL.Views.NewQuery
{
    public partial class NewQueryView : Window
    {

        public NewQueryView() : base("Create a new query")
        {

            this.BuildVisuals();
        }
    }
}

