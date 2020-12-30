namespace SharemundoBulgaria.Areas.Administration.Services.AddJobPosition
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Resources;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Localization;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddJobPosition.InputModels;
    using SharemundoBulgaria.Data;
    using SharemundoBulgaria.Models.Job;

    public class AddJobPositionService : IAddJobPositionService
    {
        private readonly ApplicationDbContext db;

        public AddJobPositionService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddJobPosition(AddJobPositionInputModel model)
        {
            this.db.JobPositions.Add(new JobPosition
            {
                Title = model.Title,
                TitleBg = model.TitleBg,
                Location = model.Location,
                LocationBg = model.LocationBg,
                CreatedOn = DateTime.UtcNow,
                Description = model.SanitizedDescription,
                DescriptionBg = model.SanitizedDescriptionBg,
            });

            await this.db.SaveChangesAsync();
        }
    }
}