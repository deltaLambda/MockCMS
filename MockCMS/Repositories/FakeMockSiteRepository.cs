using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MockCMS.Models;
using MockCMS.ViewModels;

namespace MockCMS.Repositories
{
    public class FakeMockSiteRepository : IRepository<MockSite>
    {
        private IList<MockSite> sites;

        public FakeMockSiteRepository()
        {
            sites = new List<MockSite>();
        }
        public MockSite Get(int id)
        {
            return sites.Where(site => site.Id == id).SingleOrDefault();
        }

        public void Create(MockSite newSite)
        {
            MockSite createdSite;
            if(sites.Any())
                createdSite = new MockSite(sites.Max(site => site.Id) + 1);
            else
                createdSite = new MockSite(1);
            createdSite.Name = newSite.Name;
            sites.Add(createdSite);
        }

        public void Delete(MockSite siteToBeRemoved)
        {
            if(siteToBeRemoved!=null)
                sites.Remove(siteToBeRemoved);
        }
        public void Update(MockSite updatedSite)
        {
        }
        public IList<MockSite> Get()
        {
            return sites;
        }
    }
}