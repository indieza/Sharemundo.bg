namespace SharemundoBulgaria.Services.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using SharemundoBulgaria.Constraints;
    using SharemundoBulgaria.Data;
    using SharemundoBulgaria.Models.User;

    public class HomeServices : IHomeServices
    {
        private readonly ApplicationDbContext db;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeServices(
            ApplicationDbContext db,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<bool> HasAdministrator()
        {
            var isAdminRoleExist = await this.roleManager.FindByNameAsync(Constants.AdministratorRole);
            if (isAdminRoleExist == null)
            {
                await this.roleManager.CreateAsync(new ApplicationRole
                {
                    Name = Constants.AdministratorRole,
                    RoleLevel = 1,
                });
            }

            var adminRole = await this.db.Roles
                .FirstOrDefaultAsync(x => x.Name == Constants.AdministratorRole);
            var adminsCount = await this.db.UserRoles
                .CountAsync(x => x.RoleId == adminRole.Id && x.UserId != null);

            return adminsCount != 0;
        }

        public async Task SubmitAllRoles()
        {
            var isUserRoleExist = await this.roleManager.FindByNameAsync(Constants.UserRole);
            var isAdminRoleExist = await this.roleManager.FindByNameAsync(Constants.AdministratorRole);

            if (isUserRoleExist == null)
            {
                await this.roleManager.CreateAsync(new ApplicationRole
                {
                    Name = Constants.UserRole,
                    RoleLevel = 2,
                });
            }

            if (isAdminRoleExist == null)
            {
                await this.roleManager.CreateAsync(new ApplicationRole
                {
                    Name = Constants.AdministratorRole,
                    RoleLevel = 1,
                });
            }
        }
    }
}