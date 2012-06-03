using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MockCMS.Services;
using MockCMS.ViewModels;

namespace MockCMS.Controllers
{
    public class MockSiteController : Controller
    {
        private readonly IMockSiteService siteService;

        public MockSiteController(IMockSiteService _siteService)
        {
            siteService = _siteService;
        }

        public ActionResult Index()
        {
            var model = new SiteListModel(){ Sites = siteService.GetSites() };
            return View(model);
        }

        public ActionResult ViewSite(string id, string path)
        {
            Guid siteId;
            if (!Guid.TryParse(id, out siteId))
                return new HttpNotFoundResult();
            var site = siteService.GetSite(siteId);
            if(site==null)
                return new HttpNotFoundResult();
            var siteViewModel = new SiteViewModel();
            siteViewModel.Site = site;
            return View(siteViewModel); 
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateSiteModel newSiteValues)
        {
            try
            {
                if(ModelState.IsValid)
                    siteService.CreateSite(newSiteValues);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ManageSite(int id)
        {
            return View();
        }



        [HttpPost]
        public ActionResult ManageSite(int id, ManageSiteModel siteValues)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ManageItemTypes(string id)
        {
            Guid siteId;
            if (!Guid.TryParse(id, out siteId))
                return new HttpNotFoundResult();
            var site = siteService.GetSite(siteId);
            if (site == null)
                return new HttpNotFoundResult();
            var siteViewModel = new SiteViewModel();
            siteViewModel.Site = site;

            var manageItemTypesModel = new ManageItemTypesModel(site.GetId());
            return View(manageItemTypesModel);
        }
        [HttpPost]
        public ActionResult ManageItemTypes(string id, ManageItemTypesModel itemTypesModel)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
