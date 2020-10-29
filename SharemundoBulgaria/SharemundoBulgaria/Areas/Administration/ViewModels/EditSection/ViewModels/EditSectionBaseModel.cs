namespace SharemundoBulgaria.Areas.Administration.ViewModels.EditSection.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditSection.InputModels;

    public class EditSectionBaseModel
    {
        public EditSectionViewModel EditSectionViewModel { get; set; } = new EditSectionViewModel();

        public EditSectionInputModel EditSectionInputModel { get; set; } = new EditSectionInputModel();
    }
}