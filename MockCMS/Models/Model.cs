using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockCMS.Models
{
    public class Model
    {
        public Model() { }
        public Model(int _id)
                {
            Id = _id;
        }
        public string Name { get; set; }
        public int Id { get; private set; }
   }
}