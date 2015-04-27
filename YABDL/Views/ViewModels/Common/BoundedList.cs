using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using YABDL.Tools.Extensions;
using System.Collections.Specialized;
using YABDL.Views.ViewModels;
using System.Linq;
using MoreLinq;

namespace YABDL.Views.ViewModels.Common
{
    /// <summary>
    /// Unidirectionnal viewmodel to model bounded list.
    /// </summary>
    public sealed class BoundedList<TViewModel, TModel> : ObservableCollection<TViewModel>
        where TViewModel : IViewModel<TModel>
    {
        private readonly IList<TModel> items;
        public BoundedList(IList<TModel> items, Func<TModel, TViewModel> toViewModel) : base(items.Select(toViewModel.ThrowIfNull("Transform delegate cannot be null")))
        {
            this.items = items.ThrowIfNull();
            this.CollectionChanged += this.ChangeInternalList;
        }

        private void ChangeInternalList(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Reset:
                    // Clear and refill whole collection
                    this.items.Clear();
                    foreach (var item in (sender as IEnumerable<TViewModel>).ThrowIfNull("Sender isn't a collection of type : " + typeof(TViewModel)))
                    {
                        this.items.Add(item.Model);
                    }
                    break;

                case NotifyCollectionChangedAction.Add:
                    // Add new items to collections
                    if (e.NewItems != null)
                    {
                        foreach (TViewModel item in e.NewItems)
                        {
                            this.items.Add(item.Model);
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
                        foreach (TViewModel item in e.OldItems)
                        {
                            this.items.Remove(item.Model);
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

