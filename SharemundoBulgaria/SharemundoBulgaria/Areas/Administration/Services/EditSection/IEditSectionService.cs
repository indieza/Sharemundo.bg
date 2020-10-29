namespace SharemundoBulgaria.Areas.Administration.Services.EditSection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditSection.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditSection.ViewModels;

    public interface IEditSectionService
    {
        Dictionary<string, string> GetAllSections();

        Task<GetSectionDataViewModel> GetSectionById(string sectionId);

        Task EditSection(EditSectionInputModel model);
    }
}