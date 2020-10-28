namespace SharemundoBulgaria.Areas.Administration.Services.AddPartToSection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddPartToSection.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddPartToSection.ViewModels;
    using SharemundoBulgaria.Models.Enums;

    public interface IAddPartToSectionService
    {
        Dictionary<string, string> GetAllSections();

        Task<string> AddPartToSection(AddPartToSectionInputModel model);

        Dictionary<string, PartType> GetAllElements(string path);
    }
}