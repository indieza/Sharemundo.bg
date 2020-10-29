namespace SharemundoBulgaria.Areas.Administration.ViewModels.EditPart.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EditPartViewModel
    {
        public Dictionary<string, string> AllParts { get; set; } = new Dictionary<string, string>();

        public Dictionary<string, string> AllSections { get; set; } = new Dictionary<string, string>();
    }
}