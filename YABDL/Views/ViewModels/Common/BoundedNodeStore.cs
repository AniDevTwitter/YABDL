using System;
using Gtk;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using YABDL.Tools.Extensions;
using MoreLinq;

namespace YABDL.Views.ViewModels.Common
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
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Reset:
                    // Clear and refill whole collection
                    this.Clear();
                    foreach (var item in (sender as IEnumerable<T>).ThrowIfNull("Sender isn't a collection of type : " + typeof(T)))
                    {
                        this.AddNode(item);
                    }
                    break;

                case NotifyCollectionChangedAction.Add:
                    // Add new items to collections
                    if (e.NewItems != null)
                    {
                        foreach (T item in e.NewItems)
                        {
                            this.AddNode(item);
                        }
                    }
                    break;

                case NotifyCollectionChangedAction.Move:
                    // todo
                    break;

                case NotifyCollectionChangedAction.Remove:
                    // Remove old items from collection
                    if (e.OldItems != null)
                    {
                        foreach (T item in e.OldItems)
                        {
                            this.RemoveNode(item);
                        }
                    }
                    break;

                case NotifyCollectionChangedAction.Replace:
                    // todo
                    break;


                default:
                    throw new NotSupportedException("Following action isn't supported in this listener : " + e.Action);

            }
        }
    }
}

