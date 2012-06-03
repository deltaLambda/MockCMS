using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MockCMS.Models;
using MockCMS.ViewModels;

namespace MockCMS.Services
{
    public interface IMockSiteService : IService
    {
        IMockSite GetSite(Guid id);
        IList<IMockSite> GetSites();
        void DeleteSite(Guid id);
        void CreateSite(CreateSiteModel newSiteValues);
    }
}
