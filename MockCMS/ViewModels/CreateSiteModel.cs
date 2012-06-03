using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MockCMS.ViewModels
{
    public class CreateSiteModel
    {
        [Required]
        public string Name { get; set; }
    }
}