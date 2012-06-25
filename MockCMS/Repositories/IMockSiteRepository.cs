using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MockCMS.Models;
using MockCMS.ViewModels;

namespace MockCMS.Repositories
{
    public interface IMockSiteRepository : IRepository
    {
        MockSite GetSite(int id);
        void AddSite(MockSite newSite);
        void RemoveSite(int id);
        IList<MockSite> GetAllSites();
    }
}
