using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MockCMS.Controllers;
using MockCMS.Models;
using MockCMS.Repositories;
using MockCMS.ViewModels;
using NUnit.Framework;

namespace MockCMS.Tests
{
    [TestFixture]
    public class ControllerTests
    {
        IRepository<MockSite> repository;
        MockSiteController controller;
        MockSite testSite;
        [SetUp]
        public void IntitializeController()
        {
            repository = new FakeMockSiteRepository();
            controller = new MockSiteController(repository);
            controller.Request = new System.Net.Http.HttpRequestMessage();
            testSite = new MockSite();
            testSite.Name = "Test Site";
        }
        [Test]
        public void CanCreateSite()
        {
            //Arrange - Specify values for the new site
            var newSiteValues = new CreateSiteModel { Name = "New Site" };

            //Act - Command the controller to create a new site with the specified values.
            var response = controller.Put(newSiteValues);

            //Assert - Verify that a site has been created with the specified values.
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsTrue(repository.Get().Any(site => site.Name == newSiteValues.Name));
        }
        [Test]
        public void CanAddItemTypeToSite()
        {
            //Arrange - Specify Values for new item type. Make sure a site already exists within the repo.
            repository.Create(testSite);
            var siteBeingUpdated = repository.Get().First();
            var updateModel = new UpdateSiteModel{ Id = siteBeingUpdated.GetId().Value};
            updateModel.ItemTypes.Add(new ItemTypeEditModel { Name = "Test Item Type" });

            //Act - Command the controller to update the site given the update values.
            var response = controller.Post(updateModel);

            //Assert
            var updatedSite = repository.Get(updateModel.Id);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotEmpty(siteBeingUpdated.ItemTypes);
            Assert.AreEqual("Test Item Type", siteBeingUpdated.ItemTypes.First().Name);
        }
        [Test]
        public void CanAddItemTypeWithPropertiesToSite()
        {
            //Arrange - Specify Values for new item type. 
            repository.Create(testSite);
            var siteBeingUpdated = repository.Get().First();
            var updateModel = new UpdateSiteModel { Id = siteBeingUpdated.GetId().Value };
            var testItemType = new ItemTypeEditModel { Name = "Test Item Type" };
            
            testItemType.Properties.Add(new ItemPropertyEditModel { Name = "Test Item Property", PropertyType = 1});
            updateModel.ItemTypes.Add(testItemType);

            //Act - Command the controller to update the site given the update values.
            var response = controller.Post(updateModel);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotEmpty(siteBeingUpdated.ItemTypes.First().Properties);
            Assert.AreEqual("Test Item Type", siteBeingUpdated.ItemTypes.First().Name);
        }
        [Test]
        public void CanAddPageToSite()
        {
            //Arrange - Specify values for new page. 
            repository.Create(testSite);
            var pageModel = new MockPageEditModel ();
            var siteToBeTested = repository.Get().First();
            var siteModel = new UpdateSiteModel { Id = siteToBeTested.GetId().Value};
            siteModel.Pages.Add(pageModel);
            //Act - Command the controller to update the site with the page's values.
            var response = controller.Post(siteModel);

            //Assert - Make sure that the page is contained within the site in the repository. 
            Assert.IsNotEmpty(siteToBeTested.Pages);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [Test]
        public void CanDeleteSite()
        {
            //Arrange - Add the site to the repository.
            repository.Create(testSite);
            var siteToBeDeleted = repository.Get().First();
            //Act - Invoke the controller's delete method.
            var deleteSiteModel = new DeleteSiteModel { Id = siteToBeDeleted.GetId().Value };
            var response = controller.Delete(deleteSiteModel);
            //Assert - Make sure that the site and all things that were attached to it aer no longer in the repository-like.
            Assert.IsNull(repository.Get(siteToBeDeleted.GetId().Value));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
