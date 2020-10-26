namespace SharemundoBulgaria.Areas.Administration.Services.AddSectionToPage
{
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddSectionToPage.InputModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAddSectionToPageService
    {
        Task AddSectionToPage(AddSectionToPageInputModel model);
    }
}