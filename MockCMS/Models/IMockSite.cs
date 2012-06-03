using System;
using System.Collections.Generic;

namespace MockCMS.Models
{
    public interface IMockSite : IModel
    {
        IList<MockCMS.Models.IDataView> DataViews { get; set; }

        IList<IItemType> ItemTypes { get; set; }
    }
}
