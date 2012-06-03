using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MockCMS.Models;
using MockCMS.Repositories;
using MockCMS.ViewModels;

namespace MockCMS.Services
{
    public class MockSiteService : IMockSiteService
    {
        private readonly IMockSiteRepository mockSiteRepository;
        public MockSiteService(IMockSiteRepository _mockSiteRepository)
        {
            mockSiteRepository = _mockSiteRepository;
        }
        public IMockSite GetSite(Guid id)
        {
            return mockSiteRepository.GetSite(id);
        }

        public IList<IMockSite> GetSites()
        {
            return mockSiteRepository.GetAllSites();
        }

        public void DeleteSite(Guid id)
        {
            mockSiteRepository.RemoveSite(id);
        }
        public void CreateSite(CreateSiteModel newSiteValues)
        {
            mockSiteRepository.AddSite(newSiteValues);
        }
    }
}