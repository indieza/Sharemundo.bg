namespace SharemundoBulgaria.Areas.Administration.Services.AddSectionToPage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddSectionToPage.InputModels;

    public interface IAddSectionToPageService
    {
        Task AddSectionToPage(AddSectionToPageInputModel model);
    }
}