using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MockCMS.ViewModels
{
    public class ManageSiteModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}