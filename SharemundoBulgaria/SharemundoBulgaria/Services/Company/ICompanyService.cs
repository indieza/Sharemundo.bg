namespace SharemundoBulgaria.Services.Company
{
    using SharemundoBulgaria.ViewModels.Section;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICompanyService
    {
        Task<ICollection<SectionViewModel>> GetAllCompanySections();
    }
}