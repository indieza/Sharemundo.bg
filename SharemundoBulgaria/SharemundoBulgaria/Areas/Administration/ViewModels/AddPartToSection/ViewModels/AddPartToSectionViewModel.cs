namespace SharemundoBulgaria.Areas.Administration.ViewModels.AddPartToSection.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Models.Enums;

    public class AddPartToSectionViewModel
    {
        public Dictionary<string, string> AllSections { get; set; } = new Dictionary<string, string>();

        public Dictionary<string, PartType> AllElements { get; set; } = new Dictionary<string, PartType>();
    }
}