using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Multiple_Language.Models
{
    public class SampleForm
    {
        [Display(Name = "Name", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "NameRequired")]
        public string Name
        {
            get;
            set;
        }
    }
}