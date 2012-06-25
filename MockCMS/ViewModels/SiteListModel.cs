using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MockCMS.Models;

namespace MockCMS.ViewModels
{
    public class SiteListModel
    {
        public IList<MockSite> Sites { get; set; }
    }
}