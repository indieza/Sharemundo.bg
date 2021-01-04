namespace SharemundoBulgaria.Services.Home
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Models.User;
    using SharemundoBulgaria.ViewModels.Section;

    public interface IHomeService
    {
        Task SubmitAllRoles();

        Task<bool> HasAdministrator();

        Task MakeYourselfAdmin(ApplicationUser currentUser);

        Task<ICollection<SectionViewModel>> GetAllHomeSections(string culture);
    }
}