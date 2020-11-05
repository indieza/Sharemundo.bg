namespace SharemundoBulgaria.Areas.Administration.ViewModels.RemoveJobPosition.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class RemoveJobPositionInputModel
    {
        [Required]
        [Display(Name = "Job Title")]
        public string Id { get; set; }
    }
}