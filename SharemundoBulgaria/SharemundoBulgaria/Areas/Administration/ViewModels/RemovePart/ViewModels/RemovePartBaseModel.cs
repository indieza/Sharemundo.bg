namespace SharemundoBulgaria.Areas.Administration.ViewModels.RemovePart.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.RemovePart.InputModels;

    public class RemovePartBaseModel
    {
        public RemovePartViewModel RemovePartViewModel { get; set; } = new RemovePartViewModel();

        public RemovePartInputModel RemovePartInputModel { get; set; } = new RemovePartInputModel();
    }
}