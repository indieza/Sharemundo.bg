namespace SharemundoBulgaria.Areas.Administration.Services.AddJobPosition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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
                Location = model.Location,
                CreatedOn = DateTime.UtcNow,
                Description = model.SanitizedDescription,
            });

            await this.db.SaveChangesAsync();
        }
    }
}