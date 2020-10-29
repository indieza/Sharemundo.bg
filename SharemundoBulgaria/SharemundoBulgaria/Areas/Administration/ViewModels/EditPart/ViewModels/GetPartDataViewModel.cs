namespace SharemundoBulgaria.Areas.Administration.ViewModels.EditPart.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Models.Enums;

    public class GetPartDataViewModel
    {
        public PartType PartType { get; set; }

        public string SectionId { get; set; }

        public string Name { get; set; }

        public string Heading { get; set; }

        public string Subheading { get; set; }

        public string Description { get; set; }
    }
}