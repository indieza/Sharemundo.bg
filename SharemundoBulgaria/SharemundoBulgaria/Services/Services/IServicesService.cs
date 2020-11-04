namespace SharemundoBulgaria.Services.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.ViewModels.Section;

    public interface IServicesService
    {
        Task<ICollection<SectionViewModel>> GetAllServicesSections();
    }
}