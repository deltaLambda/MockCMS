using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockCMS.Models
{
    public interface IItemProperty : IModel
    {
        string Value { get; set; }

        IItemPropertyType ItemPropertyType { get; set; }
    }
}
