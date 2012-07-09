using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockCMS.Models
{
    public class ItemType : Model
    {
        public ItemType(int _id) : base(_id)
        {
            Properties = new Dictionary<string,ItemProperty>();
        }
        public IDictionary<string, ItemProperty> Properties { get; set; }
    }
}