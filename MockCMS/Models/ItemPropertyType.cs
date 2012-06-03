using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockCMS.Models
{
    public class ItemPropertyType : Model, IItemPropertyType   
    {
        public ItemPropertyType(Guid _id)
            : base(_id)
        { }
    }
}