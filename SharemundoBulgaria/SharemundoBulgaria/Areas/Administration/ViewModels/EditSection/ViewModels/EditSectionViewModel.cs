namespace SharemundoBulgaria.Areas.Administration.ViewModels.EditSection.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EditSectionViewModel
    {
        public Dictionary<string, string> AllSections { get; set; } = new Dictionary<string, string>();
    }
}