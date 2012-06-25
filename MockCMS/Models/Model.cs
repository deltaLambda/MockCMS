using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockCMS.Models
{
    public class Model
    {
        private int? id;

        public Model() { }
        public Model(int _id)
                {
            id = _id;
        }
        public string Name { get; set; }
        public int? GetId()
        {
            return id;
        }
    }
}