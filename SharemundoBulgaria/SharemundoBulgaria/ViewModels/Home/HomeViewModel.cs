namespace SharemundoBulgaria.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.ViewModels.Section;

    public class HomeViewModel
    {
        public bool HasAdmin { get; set; }

        public ICollection<SectionViewModel> AllSections { get; set; } = new HashSet<SectionViewModel>();
    }
}