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
        private readonly IRepository<MockSite> repository;
        public MockSiteController(IRepository<MockSite> _repository)
        {
            repository = _repository;
        }
        public HttpResponseMessage Put(CreateSiteModel newSiteValues)
        {
            var site = new MockSite();
            site.Name = newSiteValues.Name;

            repository.Create(site);
            var response = Request.CreateResponse(HttpStatusCode.Created);

            return response;
        }
        public HttpResponseMessage Post(UpdateSiteModel updateModel)
        {
            var site = new MockSite(updateModel.Id);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        public HttpResponseMessage Delete(DeleteSiteModel deleteSiteModel)
        {
            var site = repository.Get(deleteSiteModel.Id);
            repository.Delete(site);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}
