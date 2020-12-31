namespace SharemundoBulgaria.Areas.Administration.ViewModels.EditJobPosition.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Ganss.XSS;

    public class EditJobPositionInputModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Title { get; set; }

        [Required]
        [MaxLength(120)]
        public string TitleBg { get; set; }

        [Required]
        [MaxLength(70)]
        public string Location { get; set; }

        [Required]
        [MaxLength(70)]
        public string LocationBg { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string DescriptionBg { get; set; }

        public string SanitizeDescription => new HtmlSanitizer().Sanitize(this.Description);

        public string SanitizeDescriptionBg => new HtmlSanitizer().Sanitize(this.DescriptionBg);
    }
}