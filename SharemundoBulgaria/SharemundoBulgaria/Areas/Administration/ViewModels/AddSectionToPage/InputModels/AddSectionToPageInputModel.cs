namespace SharemundoBulgaria.Areas.Administration.ViewModels.AddSectionToPage.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Models.Enums;

    public class AddSectionToPageInputModel
    {
        [Required]
        [Display(Name = "Page Name")]
        public Pages PageName { get; set; }

        [Required]
        [Display(Name = "Section Name")]
        public Sections SectionName { get; set; }
    }
}