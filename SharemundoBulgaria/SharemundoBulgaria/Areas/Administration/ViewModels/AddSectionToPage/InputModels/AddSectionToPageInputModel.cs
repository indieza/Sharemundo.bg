﻿namespace SharemundoBulgaria.Areas.Administration.ViewModels.AddSectionToPage.InputModels
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

        [Display(Name = "Section Subheading")]
        public string Subheading { get; set; }

        [Display(Name = "Section Description")]
        public string Description { get; set; }

        [Display(Name = "Section Image")]
        public IFormFile Image { get; set; }

        public string SanitizeDescription => new HtmlSanitizer().Sanitize(this.Description);
    }
}