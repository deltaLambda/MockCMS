using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockCMS.Models
{
    public interface IItemType : IModel
    {
        IDictionary<string, IItemPropertyType> Properties { get; set; }
    }
}
