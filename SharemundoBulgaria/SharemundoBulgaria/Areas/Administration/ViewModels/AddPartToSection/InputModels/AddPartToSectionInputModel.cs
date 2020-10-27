namespace SharemundoBulgaria.Areas.Administration.ViewModels.AddPartToSection.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Ganss.XSS;
    using Microsoft.AspNetCore.Http;
    using SharemundoBulgaria.Models.Enums;

    public class AddPartToSectionInputModel
    {
        [Required]
        [MaxLength(120)]
        [Display(Name = "Part Name")]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(PartType), ErrorMessage = "The part type is invalid")]
        [Display(Name = "Part Type")]
        public PartType PartType { get; set; }

        [Required]
        public int PositionNumber { get; set; }

        [Required]
        [Display(Name = "Section Name")]
        public string SectionId { get; set; }

        [Display(Name = "Part Heading")]
        public string Heading { get; set; }

        [Display(Name = "Part Subheading")]
        public string Subheading { get; set; }

        [Display(Name = "Part Description")]
        public string Description { get; set; }

        [Display(Name = "Part Image")]
        public IFormFile Image { get; set; }

        public string SanitizeDescription => new HtmlSanitizer().Sanitize(this.Description);
    }
}