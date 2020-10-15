namespace SharemundoBulgaria.Services.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using SharemundoBulgaria.Constraints;
    using SharemundoBulgaria.Data;
    using SharemundoBulgaria.Models.User;

    public class HomeServices : IHomeServices
    {
        private readonly ApplicationDbContext db;
        private readonly RoleManager<ApplicationRole> roleManager;

        public HomeServices(ApplicationDbContext db, RoleManager<ApplicationRole> roleManager)
        {
            this.db = db;
            this.roleManager = roleManager;
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