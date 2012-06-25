using System;
using System.Collections.Generic;
using System.Linq;

namespace MockCMS.Models
{
    public class MockSite : Model
    {
        public MockSite()
            : base()
        {
            ItemTypes = new List<ItemType>();
            ItemPropertyTypes = new List<ItemPropertyType>();
        }
        public MockSite(int _id)
            : base(_id)
        {
            ItemTypes = new List<ItemType>();
            ItemPropertyTypes = new List<ItemPropertyType>();
        }

        public IList<ItemType> ItemTypes { get; set; }

        public IList<ItemPropertyType> ItemPropertyTypes { get; set; }
    }
}