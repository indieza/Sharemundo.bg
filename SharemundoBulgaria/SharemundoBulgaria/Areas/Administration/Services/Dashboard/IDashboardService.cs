namespace SharemundoBulgaria.Areas.Administration.Services.Dashboard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Models.User;

    public interface IDashboardService
    {
        Task<int> GetAllUsersCount();

        Task<int> GetAllAdminsCount();

        ICollection<ApplicationUser> GetAllUsers();

        Task<ICollection<string>> GetAllAdminsNames();

        Task<ICollection<string>> GetAllNotAdminsNames();

        Task RemoveAdministrator(string username);

        Task AddAdministrator(string username);
    }
}