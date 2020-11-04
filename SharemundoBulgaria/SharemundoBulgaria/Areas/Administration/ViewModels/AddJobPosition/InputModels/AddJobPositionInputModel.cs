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
        [MaxLength(70)]
        public string Location { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string Description { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);
    }
}