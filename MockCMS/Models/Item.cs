using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MockCMS.Models
{
    public class Item : Model
    {
        public Item(int _id) : base(_id)
        {
            Properties = new List<ItemProperty>();
        }
        public ItemType Type { get; set; }

        public IList<ItemProperty> Properties { get; set; }
    }
}