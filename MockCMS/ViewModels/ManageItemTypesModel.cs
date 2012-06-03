using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MockCMS.ViewModels
{
    public class ManageItemTypesModel
    {
        public ManageItemTypesModel(Guid _siteId)
        {
            SiteId = _siteId;
            ItemTypes = new List<ItemTypeEditModel>();
        }
        public IList<ItemTypeEditModel> ItemTypes { get; set; }
        public Guid SiteId { get; private set; }
    }
    public class ItemTypeEditModel
    {
        public ItemTypeEditModel()
        {
            Properties = new List<ItemPropertyEditModel>();
        }
        [Required]
        public string Name { get; set; }

        public IList<ItemPropertyEditModel> Properties { get; set; }
    }
    public class ItemPropertyEditModel
    {
        [Required]
        public string Name { get; set ;}
        public int PropertyType { get; set; }
    }
}