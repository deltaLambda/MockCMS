using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockCMS.Models
{
    public interface IItem : IModel 
    {
        IItemType Type { get; set; }

        IList<IItemProperty> Properties { get; set; }
    }
}
