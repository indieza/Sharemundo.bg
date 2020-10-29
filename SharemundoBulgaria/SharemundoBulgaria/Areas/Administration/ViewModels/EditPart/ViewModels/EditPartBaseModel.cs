namespace SharemundoBulgaria.Areas.Administration.ViewModels.EditPart.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditPart.InputModels;

    public class EditPartBaseModel
    {
        public EditPartViewModel EditPartViewModel { get; set; } = new EditPartViewModel();

        public EditPartInputModel EditPartInputModel { get; set; } = new EditPartInputModel();
    }
}