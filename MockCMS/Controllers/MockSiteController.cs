﻿using System;
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
            var site = new MockSite { Name = newSiteValues.Name };

            repository.Create(site);
            var response = Request.CreateResponse(HttpStatusCode.Created);

            return response;
        }
        public HttpResponseMessage Post(UpdateSiteModel updateModel)
        {
            var site = repository.Get(updateModel.Id);
            //This is where we do the updating. 
            site.Name = updateModel.Name;
            //This section for the newly created values.
            foreach (var itemTypeModel in updateModel.ItemTypes.Where(itemType => itemType.Id == 0))
            {
                //Determine whether or not the list of item types is empty to determine the key for the new item type.
                var idOfNewItemType = site.ItemTypes.Any()
                    ? site.ItemTypes.Max(itemType => itemType.Id) + 1 : 1;
                //Create the item type and populate its properties. 
                var newItemType = new ItemType(idOfNewItemType);
                newItemType.Name = itemTypeModel.Name;
                foreach(var itemPropertyModel in itemTypeModel.Properties)
                {
                    var newPropertyId = newItemType.Properties.Any()
                                            ? newItemType.Properties.Max(propKvp => propKvp.Value.Id) + 1
                                            : 1;
                    var newProperty = new KeyValuePair<string, ItemProperty>(itemPropertyModel.Name, new ItemProperty(newPropertyId));
                    newItemType.Properties.Add(newProperty);
                }
                //Finally, add the item type.
                site.ItemTypes.Add(newItemType);
            }
            //Let's go over the page properties and stuff. 
            //Determine the id of the new page.
            foreach (var mockPageModel in updateModel.Pages.Where( page => page.Id == 0))
            {
                var idOfNewPage = site.Pages.Any() ? site.Pages.Max(page => page.Id) + 1 : 1;
                var newPage = new MockPage(idOfNewPage);
                newPage.Html = mockPageModel.Html;
                newPage.Name = mockPageModel.Name;
                site.Pages.Add(newPage);
            }           
            //This section for the values that we are going to update.
            foreach( var itemTypeModel in updateModel.ItemTypes.Where(itemType => itemType.Id > 0))
            {
                var itemTypeBeingModified = site.ItemTypes.SingleOrDefault(itemType => itemType.Id == itemTypeModel.Id);
                itemTypeBeingModified.Name = itemTypeModel.Name;
                //Find the newly created properties on the item type. 
                foreach( var itemPropertyModel in updateModel.ItemTypes.Where(prop => prop.Id == 0))
                {
                    var newPropertyId = itemTypeBeingModified.Properties.Any()
                        ? itemTypeBeingModified.Properties.Max(propKvp => propKvp.Value.Id) + 1
                        : 1;
                    var newProperty = new KeyValuePair<string, ItemProperty>(itemPropertyModel.Name, new ItemProperty(newPropertyId));
                    itemTypeBeingModified.Properties.Add(newProperty);
                }
                foreach( var itemPropertyModel in updateModel.ItemTypes.Where(prop => prop.Id > 0))
                {
                    
                }
            }
            foreach (var pageModel in updateModel.Pages.Where(page => page.Id > 0))
            {
                var pageBeingModified = site.Pages.SingleOrDefault(page => page.Id == pageModel.Id);
                pageBeingModified.Name = pageModel.Name;
            }
            //Tell the Repository to commit the changes
            repository.Update(site);
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

