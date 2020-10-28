namespace SharemundoBulgaria.Areas.Administration.ViewModels.RemovePart.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class RemovePartInputModel
    {
        [Display(Name = "Part Name")]
        [Required]
        public string Id { get; set; }
    }
}