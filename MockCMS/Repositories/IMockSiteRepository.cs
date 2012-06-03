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
        IMockSite GetSite(Guid id);
        void AddSite(CreateSiteModel newSiteValues);
        void RemoveSite(Guid id);
        IList<IMockSite> GetAllSites();
    }
}
