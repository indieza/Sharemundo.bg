namespace SharemundoBulgaria.Areas.Administration.ViewModels.AddSectionToPage.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Models.Enums;

    public class AddSectionToPageViewModel
    {
        public Dictionary<string, SectionType> AllElements { get; set; } = new Dictionary<string, SectionType>();
    }
}