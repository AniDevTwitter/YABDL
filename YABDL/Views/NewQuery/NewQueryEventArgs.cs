using System;
using YABDL.Models.Interfaces;
using System.Collections.Generic;

namespace YABDL.Views.NewQuery
{
    public class NewQueryEventArgs : EventArgs
    {
        public NewQueryEventArgs(string label, List<Guid> providersIds, string tags, string outputFolder)
        {
            this.Label = label;
            this.ProvidersIds = providersIds;
            this.Tags = tags;
            this.OutputFolder = outputFolder;
        }

        public string Label { get; set;}
        public List<Guid> ProvidersIds { get; set;}
        public string Tags { get; set;}
        public string OutputFolder { get; set;}

        public IQuery AsQuery(IFactory factory)
        {
            return factory.NewQuery(this.Label, this.ProvidersIds, this.Tags, this.OutputFolder);
        }
    }
}

