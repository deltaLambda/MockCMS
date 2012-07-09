using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockCMS.ViewModels
{
    public class MockPageEditModel
    {
        public int Id { get; set; }

        public string Html { get; set; }

        public string Name
        {
            get ; 
            set ; 
        }
    }
}