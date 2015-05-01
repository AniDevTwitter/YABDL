using System;
using System.Collections.Generic;

namespace YABDL.Models.Interfaces
{
    public interface IFactory
    {
        IProvider NewProvider(string name, string url);
        IQuery NewQuery(string name, List<Guid> providersIds, string tags, string outputFolder);
    }
}

