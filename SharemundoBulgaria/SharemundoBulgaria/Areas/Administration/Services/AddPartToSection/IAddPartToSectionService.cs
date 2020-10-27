namespace SharemundoBulgaria.Areas.Administration.Services.AddPartToSection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddPartToSection.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddPartToSection.ViewModels;

    public interface IAddPartToSectionService
    {
        AddPartToSectionViewModel GetAllSections();

        Task<string> AddPartToSection(AddPartToSectionInputModel model);
    }
}