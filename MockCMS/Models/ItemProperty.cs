using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockCMS.Models
{
    public class ItemProperty : Model,  IItemProperty
    {
        public ItemProperty(Guid _id) : base(_id) { }
        public string Value { get; set; }

        public IItemPropertyType ItemPropertyType { get; set; }
    }
}