namespace SharemundoBulgaria.Areas.Administration.Services.Dashboard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using SharemundoBulgaria.Constraints;
    using SharemundoBulgaria.Data;
    using SharemundoBulgaria.Models.User;

    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext db;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public DashboardService(
            ApplicationDbContext db,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task AddAdministrator(string username)
        {
            var user = await this.db.Users.FirstOrDefaultAsync(x => x.UserName == username);
            await this.userManager.AddToRoleAsync(user, Constants.AdministratorRole);
        }

        public async Task<int> GetAllAdminsCount()
        {
            var role = await this.db.Roles.FirstOrDefaultAsync(x => x.Name == Constants.AdministratorRole);
            var adminRoleId = await this.roleManager.GetRoleIdAsync(role);
            return await this.db.UserRoles.CountAsync(x => x.RoleId == adminRoleId);
        }

        public async Task<ICollection<string>> GetAllAdminsNames()
        {
            var role = await this.db.Roles.FirstOrDefaultAsync(x => x.Name == Constants.AdministratorRole);
            var adminRoleId = await this.roleManager.GetRoleIdAsync(role);
            var adminsNames = new List<string>();

            foreach (var user in this.db.Users.ToList())
            {
                if (await this.userManager.IsInRoleAsync(user, Constants.AdministratorRole))
                {
                    adminsNames.Add(user.UserName);
                }
            }

            return adminsNames;
        }

        public async Task<ICollection<string>> GetAllNotAdminsNames()
        {
            var role = await this.db.Roles.FirstOrDefaultAsync(x => x.Name == Constants.AdministratorRole);
            var adminRoleId = await this.roleManager.GetRoleIdAsync(role);
            var notAdminsNames = new List<string>();

            foreach (var user in this.db.Users.ToList())
            {
                if (!await this.userManager.IsInRoleAsync(user, Constants.AdministratorRole))
                {
                    notAdminsNames.Add(user.UserName);
                }
            }

            return notAdminsNames;
        }

        public ICollection<ApplicationUser> GetAllUsers()
        {
            return this.db.Users
                .OrderBy(x => x.UserName)
                .ThenBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();
        }

        public async Task<int> GetAllUsersCount()
        {
            return await this.db.Users.Where(x => x.EmailConfirmed == true).CountAsync();
        }

        public async Task RemoveAdministrator(string username)
        {
            var user = await this.db.Users.FirstOrDefaultAsync(x => x.UserName == username);
            await this.userManager.RemoveFromRoleAsync(user, Constants.AdministratorRole);
        }
    }
}