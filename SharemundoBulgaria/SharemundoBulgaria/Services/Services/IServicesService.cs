namespace SharemundoBulgaria.Services.Services
{
    using SharemundoBulgaria.ViewModels.Section;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IServicesService
    {
        Task<ICollection<SectionViewModel>> GetAllServicesSections();
    }
}