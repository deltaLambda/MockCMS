using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;

namespace MockCMS.Repositories
{
    public class MockSiteRepositoryModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMockSiteRepository>().To<FakeMockSiteRepository>().InTransientScope();
        }
    }
}