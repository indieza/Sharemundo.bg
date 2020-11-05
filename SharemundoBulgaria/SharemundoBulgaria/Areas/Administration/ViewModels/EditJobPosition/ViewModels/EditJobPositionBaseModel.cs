namespace SharemundoBulgaria.Areas.Administration.ViewModels.EditJobPosition.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditJobPosition.InputModels;

    public class EditJobPositionBaseModel
    {
        public ICollection<EditJobPositionViewModel> EditJobPositionViewModels { get; set; } =
            new HashSet<EditJobPositionViewModel>();

        public EditJobPositionInputModel EditJobPositionInputModel { get; set; } =
            new EditJobPositionInputModel();
    }
}