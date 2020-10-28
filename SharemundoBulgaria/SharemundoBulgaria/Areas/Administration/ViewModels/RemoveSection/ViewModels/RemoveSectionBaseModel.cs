namespace SharemundoBulgaria.Areas.Administration.ViewModels.RemoveSection.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.RemoveSection.InputModels;

    public class RemoveSectionBaseModel
    {
        public RemoveSectionViewModel RemoveSectionViewModel { get; set; } = new RemoveSectionViewModel();

        public RemoveSectionInputModel RemoveSectionInputModel { get; set; } = new RemoveSectionInputModel();
    }
}