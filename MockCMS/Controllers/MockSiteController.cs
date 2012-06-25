using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MockCMS.Models;
using MockCMS.Repositories;
using MockCMS.ViewModels;

namespace MockCMS.Controllers
{
    public class MockSiteController : ApiController
    {
        private readonly IMockSiteRepository repository;
        public MockSiteController(IMockSiteRepository _repository)
        {
            repository = _repository;
        }
        public HttpResponseMessage Put(CreateSiteModel newSiteValues)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage Post(UpdateSiteModel updateModel)
        {
            throw new NotImplementedException();
        }
    }
}
