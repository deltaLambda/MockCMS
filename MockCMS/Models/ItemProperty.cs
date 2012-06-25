using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockCMS.Models
{
    public class ItemProperty : Model
    {
        public ItemProperty(int _id) : base(_id) { }
        public string Value { get; set; }

        public ItemPropertyType ItemPropertyType { get; set; }
    }
}