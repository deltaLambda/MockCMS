using System;
using System.Collections.Generic;
using System.Linq;

namespace MockCMS.Models
{
    public class MockSite : Model, IMockSite
    {
        public MockSite(Guid _id)
            : base(_id)
        {
            DataViews = new List<IDataView>();
            ItemTypes = new List<IItemType>();
        }

        public IList<IDataView> DataViews { get; set; }

        public IList<IItemType> ItemTypes { get; set; }
    }
}