namespace SharemundoBulgaria.Areas.Administration.ViewModels.AddJobPosition.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Ganss.XSS;

    public class AddJobPositionInputModel
    {
        [Required]
        [MaxLength(120)]
        public string Title { get; set; }

        [Required]
        [MaxLength(120)]
        [Display(Name = "Title on Bulgarian")]
        public string TitleBg { get; set; }

        [Required]
        [MaxLength(70)]
        public string Location { get; set; }

        [Required]
        [MaxLength(70)]
        [Display(Name = "Location on Bulgarian")]
        public string LocationBg { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Description on Bulgarian")]
        public string DescriptionBg { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);

        public string SanitizedDescriptionBg => new HtmlSanitizer().Sanitize(this.DescriptionBg);
    }
}