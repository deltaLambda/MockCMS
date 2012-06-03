using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockCMS.Models
{
    public interface IModel
    {
        string Name { get; set; }
        Guid GetId();
    }
}
