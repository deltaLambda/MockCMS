using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MockCMS.ViewModels
{
    public class UpdateSiteModel
    {
        public UpdateSiteModel(int id)
        {
            Id = id;
            ItemTypes = new List<ItemTypeEditModel>();
            PropertyTypes = new List<ItemPropertyTypeModel>();
        }
        public int Id { get; set; }
            
        [Required]
        public string Name { get; set; }

        public IList<ItemTypeEditModel> ItemTypes { get; set; }

        public IList<ItemPropertyTypeModel> PropertyTypes { get; set; }
    }
    public class ItemTypeEditModel
    {
        public ItemTypeEditModel()
        {
            Properties = new List<ItemPropertyEditModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ItemPropertyEditModel> Properties { get; set; }
    }

    public class ItemPropertyEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PropertyType { get; set; }
    }
    public class ItemPropertyTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}