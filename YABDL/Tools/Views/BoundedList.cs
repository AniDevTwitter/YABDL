using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using YABDL.Tools.Extensions;

namespace YABDL.Tools.Views
{
    public class BoundedList<T> : ObservableCollection<T>
    {
        private readonly IList<T> items;
        public BoundedList(IList<T> items) : base(items)
        {
            this.items = items.ThrowIfNull();
            // Todo : make this class maintaning the observablecollection in sync with the list items
        }
    }
}

