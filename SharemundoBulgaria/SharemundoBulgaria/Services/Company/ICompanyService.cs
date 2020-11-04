namespace SharemundoBulgaria.Services.Company
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.ViewModels.Section;

    public interface ICompanyService
    {
        Task<ICollection<SectionViewModel>> GetAllCompanySections();
    }
}