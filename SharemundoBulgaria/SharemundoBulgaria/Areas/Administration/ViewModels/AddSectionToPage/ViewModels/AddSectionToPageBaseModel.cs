namespace SharemundoBulgaria.Areas.Administration.ViewModels.AddSectionToPage.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddSectionToPage.InputModels;

    public class AddSectionToPageBaseModel
    {
        public AddSectionToPageViewModel AddSectionToPageViewModel { get; set; } = new AddSectionToPageViewModel();

        public AddSectionToPageInputModel AddSectionToPageInputModel { get; set; } = new AddSectionToPageInputModel();
    }
}