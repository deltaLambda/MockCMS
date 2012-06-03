using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockCMS.Models
{
    public class Item : Model, IItem
    {
        public Item(Guid _id) : base(_id) { }
        public IItemType Type { get; set; }

        public IList<IItemProperty> Properties { get; set; }
    }
}