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
    using SharemundoBulgaria.Models.Enums;
    using SharemundoBulgaria.Models.User;
    using SharemundoBulgaria.ViewModels.Section;
    using SharemundoBulgaria.ViewModels.SectionPart;

    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext db;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeService(
            ApplicationDbContext db,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<ICollection<SectionViewModel>> GetAllHomeSections(string culture)
        {
            var allSections = this.db.Sections
                .Where(x => x.PageType == PageType.HOME)
                .OrderBy(x => x.PositionNumber)
                .ToList();
            var result = new List<SectionViewModel>();

            foreach (var section in allSections)
            {
                var allParts = this.db.SectionParts
                    .Where(x => x.SectionId == section.Id)
                    .OrderBy(x => x.PositionNumber)
                    .ToList();
                var sectionText = await this.db.PartTexts.FirstOrDefaultAsync(x => x.SectionId == section.Id);
                var sectionImage = await this.db.PartImages.FirstOrDefaultAsync(x => x.SectionId == section.Id);
                var currentSection = new SectionViewModel
                {
                    Id = section.Id,
                    Name = section.Name,
                    SectionType = section.SectionType,
                    Heading = culture.ToUpper() == "BG" ? sectionText?.HeadingBg : sectionText?.Heading,
                    Subheading = culture.ToUpper() == "BG" ? sectionText?.SubheadingBg : sectionText?.Subheading,
                    Description = culture.ToUpper() == "BG" ? sectionText?.DescriptionBg : sectionText?.Description,
                    Url = sectionImage?.Url,
                };

                foreach (var part in allParts)
                {
                    var partText = await this.db.PartTexts.FirstOrDefaultAsync(x => x.SectionPartId == part.Id);
                    var partImage = await this.db.PartImages.FirstOrDefaultAsync(x => x.SectionPartId == part.Id);

                    currentSection.AllParts.Add(new SectionPartViewModel
                    {
                        Id = part.Id,
                        Name = part.Name,
                        PartType = part.PartType,
                        Heading = culture.ToUpper() == "BG" ? partText?.HeadingBg : partText?.Heading,
                        Subheading = culture.ToUpper() == "BG" ? partText?.SubheadingBg : partText?.Subheading,
                        Description = culture.ToUpper() == "BG" ? partText?.DescriptionBg : partText?.Description,
                        Url = partImage?.Url,
                    });
                }

                result.Add(currentSection);
            }

            return result;
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

        public async Task MakeYourselfAdmin(ApplicationUser currentUser)
        {
            await this.userManager.AddToRoleAsync(currentUser, Constants.AdministratorRole);
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