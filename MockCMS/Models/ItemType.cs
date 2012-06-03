using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockCMS.Models
{
    public class ItemType : Model,  IItemType
    {
        public ItemType(Guid _id) : base(_id)
        {
            Properties = new Dictionary<string,IItemPropertyType>();
        }
        public IDictionary<string, IItemPropertyType> Properties { get; set; }

    }
}