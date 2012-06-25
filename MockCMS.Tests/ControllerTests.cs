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
        IMockSiteRepository repository;
        MockSiteController controller;
        MockSite testSite;
        [TestFixtureSetUp]
        public void IntitializeController()
        {
            repository = new FakeMockSiteRepository();
            controller = new MockSiteController(repository);
            testSite = new MockSite(1);
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
            Assert.AreEqual(HttpStatusCode.Created, response);
            Assert.IsTrue(repository.GetAllSites().Where(site => site.Name == newSiteValues.Name).Any());
        }
        [Test]
        public void CanAddItemType()
        {
            //Arrange - Specify Values for new item type. Make sure a site already exists within the repo.
            repository.AddSite(testSite);
            var updateModel = new UpdateSiteModel(testSite.GetId().Value);
            updateModel.ItemTypes.Add(new ItemTypeEditModel { Name = "Test Item Type" });
            //Act - Command the controller to update the site given the update values.
            var response = controller.Post(updateModel);
            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotEmpty(testSite.ItemTypes);
            Assert.AreEqual("Test Item Type", testSite.ItemTypes.First().Name);
        }
        [Test]
        public void CanAddItemTypeWithProperties()
        {
            //Arrange - Specify Values for new item type. Make sure a site already exists within the repo.
            repository.AddSite(testSite);
            var updateModel = new UpdateSiteModel(testSite.GetId().Value);
            var testItemType = new ItemTypeEditModel { Name = "Test Item Type" };
            testItemType.Properties.Add(new ItemPropertyEditModel { Name = "Test Item Property", PropertyType = 1});
            updateModel.ItemTypes.Add(testItemType);
            //Act - Command the controller to update the site given the update values.
            var response = controller.Post(updateModel);
            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotEmpty(testSite.ItemTypes.First().Properties);
            Assert.AreEqual("Test Item Type", testSite.ItemTypes.First().Properties.First().Key);
        }
    }
}
