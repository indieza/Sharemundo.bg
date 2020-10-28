namespace SharemundoBulgaria.ViewModels.Section
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Models.Enums;
    using SharemundoBulgaria.ViewModels.SectionPart;

    public class SectionViewModel
    {
        public SectionType SectionType { get; set; }

        public string Name { get; set; }

        public string Heading { get; set; }

        public string Subheading { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public ICollection<SectionPartViewModel> AllParts { get; set; } = new HashSet<SectionPartViewModel>();
    }
}