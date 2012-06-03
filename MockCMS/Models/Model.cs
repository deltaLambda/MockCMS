using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockCMS.Models
{
    public class Model : IModel
    {
        private Guid id;

        public Model(Guid _id)
        {
            id = _id;
        }
        public string Name { get; set; }
        public Guid GetId()
        {
            return id;
        }
    }
}