namespace SharemundoBulgaria.Areas.Administration.ViewModels.EditSectionsPosition.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class EditSectionsPositionInputModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int PositionNumber { get; set; }
    }
}