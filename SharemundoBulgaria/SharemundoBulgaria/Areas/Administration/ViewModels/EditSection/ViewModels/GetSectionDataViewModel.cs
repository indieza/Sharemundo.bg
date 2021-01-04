namespace SharemundoBulgaria.Areas.Administration.ViewModels.EditSection.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Models.Enums;

    public class GetSectionDataViewModel
    {
        public PageType PageType { get; set; }

        public SectionType SectionType { get; set; }

        public string Name { get; set; }

        public string Heading { get; set; }

        public string HeadingBg { get; set; }

        public string Subheading { get; set; }

        public string SubheadingBg { get; set; }

        public string Description { get; set; }

        public string DescriptionBg { get; set; }
    }
}