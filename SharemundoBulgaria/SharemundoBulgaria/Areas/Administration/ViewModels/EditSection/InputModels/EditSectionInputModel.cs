namespace SharemundoBulgaria.Areas.Administration.ViewModels.EditSection.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Ganss.XSS;
    using Microsoft.AspNetCore.Http;
    using SharemundoBulgaria.Models.Enums;

    public class EditSectionInputModel
    {
        [Display(Name = "Edit Section Name")]
        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Page Type")]
        [EnumDataType(typeof(PageType), ErrorMessage = "The page type is invalid")]
        public PageType PageType { get; set; }

        [Required]
        [Display(Name = "Section Type")]
        [EnumDataType(typeof(SectionType), ErrorMessage = "The section type is invalid")]
        public SectionType SectionType { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Section Name")]
        public string Name { get; set; }

        [Display(Name = "Section Heading")]
        public string Heading { get; set; }

        [Display(Name = "Section Heading in Bulgarian")]
        public string HeadingBg { get; set; }

        [Display(Name = "Section Subheading")]
        public string Subheading { get; set; }

        [Display(Name = "Section Subheading In Bulgarian")]
        public string SubheadingBg { get; set; }

        [Display(Name = "Section Description")]
        public string Description { get; set; }

        [Display(Name = "Section Description In Bulgarian")]
        public string DescriptionBg { get; set; }

        [Display(Name = "Section Image")]
        public IFormFile Image { get; set; }

        public string SanitizeDescription => new HtmlSanitizer().Sanitize(this.Description);

        public string SanitizeDescriptionBg => new HtmlSanitizer().Sanitize(this.DescriptionBg);
    }
}