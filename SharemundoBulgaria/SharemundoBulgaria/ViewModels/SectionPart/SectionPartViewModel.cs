namespace SharemundoBulgaria.ViewModels.SectionPart
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Models.Enums;

    public class SectionPartViewModel
    {
        public string Name { get; set; }

        public PartType PartType { get; set; }

        public string Heading { get; set; }

        public string Subheading { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }
    }
}