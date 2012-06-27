using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockCMS.Models
{
    public class MockPage : Model
    {
        public MockPage()
            : base() { }
        public MockPage(int _id)
            : base(_id) { }
        public string Path { get; set; }
        public string Html { get; set; }
        public DataView DataView { get; set; }
    }
}