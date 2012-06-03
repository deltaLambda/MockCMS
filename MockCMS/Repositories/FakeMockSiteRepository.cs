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
        private static readonly IList<IMockSite> sites;

        static FakeMockSiteRepository()
        {
            if (sites == null)
            {
                sites = new List<IMockSite>();
                for (int i = 1; i < 10; i++)
                {
                    IMockSite testSite = new MockSite(Guid.NewGuid());
                    testSite.Name = "Test Site " + i.ToString();
                    sites.Add(testSite);
                }
            }

        }
        public IMockSite GetSite(Guid id)
        {
            return sites.Where(site => site.GetId().Equals(id)).SingleOrDefault();
        }

        public void AddSite(CreateSiteModel newSiteValues)
        {
            IMockSite newSite = new MockSite(Guid.NewGuid());
            newSite.Name = newSiteValues.Name;
            sites.Add(newSite);
        }

        public void RemoveSite(Guid id)
        {
            var siteToBeRemoved = sites.Where(site => site.GetId() == id).SingleOrDefault();
            if(siteToBeRemoved!=null)
                sites.Remove(siteToBeRemoved);
        }

        public IList<IMockSite> GetAllSites()
        {
            return sites;
        }
    }
}