namespace SharemundoBulgaria.Areas.Administration.ViewModels.RemoveSection.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class RemoveSectionInputModel
    {
        [Display(Name = "Section Name")]
        [Required]
        public string Id { get; set; }
    }
}