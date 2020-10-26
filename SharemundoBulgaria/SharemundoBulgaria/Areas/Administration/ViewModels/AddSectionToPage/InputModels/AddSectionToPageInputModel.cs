namespace SharemundoBulgaria.Areas.Administration.ViewModels.AddSectionToPage.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Ganss.XSS;
    using Microsoft.AspNetCore.Http;
    using SharemundoBulgaria.Models.Enums;

    public class AddSectionToPageInputModel
    {
        [Required]
        [Display(Name = "Page Name")]
        [EnumDataType(typeof(Pages), ErrorMessage = "The page type is invalid")]
        public Pages PageName { get; set; }

        [Required]
        [Display(Name = "Section Name")]
        [EnumDataType(typeof(Sections), ErrorMessage = "The section type is invalid")]
        public Sections SectionName { get; set; }

        [Display(Name = "Section Heading")]
        public string Heading { get; set; }

        [Display(Name = "Section Subheading")]
        public string Subheading { get; set; }

        [Display(Name = "Section Description")]
        public string Description { get; set; }

        [Display(Name = "Section Image")]
        public IFormFile Image { get; set; }

        public string SanitizeDescription => new HtmlSanitizer().Sanitize(this.Description);
    }
}