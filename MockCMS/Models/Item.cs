using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockCMS.Models
{
    public class Item : Model
    {
        public Item(int _id) : base(_id) { }
        public ItemType Type { get; set; }

        public IList<ItemProperty> Properties { get; set; }
    }
}