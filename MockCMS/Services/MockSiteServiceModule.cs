using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;

namespace MockCMS.Services
{
    public class MockSiteServiceModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMockSiteService>().To<MockSiteService>().InTransientScope();
        }
    }
}