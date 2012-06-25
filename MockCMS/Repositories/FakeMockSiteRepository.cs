using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MockCMS.Models;
using MockCMS.ViewModels;

namespace MockCMS.Repositories
{
    public class FakeMockSiteRepository : IMockSiteRepository
    {
        private IList<MockSite> sites;

        public FakeMockSiteRepository()
        {
            sites = new List<MockSite>();
        }
        public MockSite GetSite(int id)
        {
            return sites.Where(site => site.GetId().Equals(id)).SingleOrDefault();
        }

        public void AddSite(MockSite newSite)
        {
            sites.Add(newSite);
        }

        public void RemoveSite(int id)
        {
            var siteToBeRemoved = sites.Where(site => site.GetId() == id).SingleOrDefault();
            if(siteToBeRemoved!=null)
                sites.Remove(siteToBeRemoved);
        }

        public IList<MockSite> GetAllSites()
        {
            return sites;
        }
    }
}