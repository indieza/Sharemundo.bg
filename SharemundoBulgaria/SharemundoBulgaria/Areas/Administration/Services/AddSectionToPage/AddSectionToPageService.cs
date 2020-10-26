namespace SharemundoBulgaria.Areas.Administration.Services.AddSectionToPage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddSectionToPage.InputModels;
    using SharemundoBulgaria.Data;
    using SharemundoBulgaria.Models.Page;

    public class AddSectionToPageService : IAddSectionToPageService
    {
        private readonly ApplicationDbContext db;

        public AddSectionToPageService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddSectionToPage(AddSectionToPageInputModel model)
        {
            int? lastSectionPositionNumber = await this.db.Sections
                .OrderByDescending(x => x.PositionNumber)
                .Select(x => x.PositionNumber)
                .FirstOrDefaultAsync();

            var section = new Section
            {
                Name = model.SectionName,
                Page = model.PageName,
                PositionNumber = lastSectionPositionNumber == null ? 0 : (int)lastSectionPositionNumber + 1,
            };

            this.db.Sections.Add(section);
            await this.db.SaveChangesAsync();
        }
    }
}