using System;
using Gtk;

namespace YABDL.Views.Common
{
    public static class AppIcons
    {
        public static Image GetIcon(string name, int size = 24, IconLookupFlags flags = 0)
        {
            return new Image(IconTheme.Default.LoadIcon(name, size, flags));
        }

        public static Image Add
        {
            get
            {
                return AppIcons.GetIcon("list-add");
            }
        } //document-save

        public static Image Save
        {
            get
            {
                return AppIcons.GetIcon("document-save");
            }
        } 

        public static Image Search
        {
            get
            {
                return AppIcons.GetIcon("system-search");
            }
        } 

        //
    }
}

