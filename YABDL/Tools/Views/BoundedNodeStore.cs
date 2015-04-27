using System;
using Gtk;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using YABDL.Tools.Extensions;
using MoreLinq;

namespace YABDL.Tools.Views
{
    public class BoundedNodeStore<T> : NodeStore
        where T : ITreeNode
    {
        public BoundedNodeStore(ObservableCollection<T> collection ) : base(typeof(T))
        {
            collection.ThrowIfNull("Collection cannot be null");
            collection.ForEach(x => this.AddNode(x));
            collection.CollectionChanged += this.OnCollectionChanged;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                this.Clear();
                foreach (var item in (sender as IEnumerable<T>).ThrowIfNull("Sender isn't a collection of type : " + typeof(T)))
                {
                    this.AddNode(item);
                }
            }
            // First remove, why ? Because an instance can be applied multiple time to collection so it CAN avoid some troubles
            if (e.OldItems != null)
            {
                foreach (T item in e.OldItems)
                {
                    this.RemoveNode(item);
                }
            }
            if (e.NewItems != null)
            {
                foreach (T item in e.NewItems)
                {
                    this.AddNode(item);
                }
            }

        }
    }
}

