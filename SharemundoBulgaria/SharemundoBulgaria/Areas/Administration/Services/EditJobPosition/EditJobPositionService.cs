namespace SharemundoBulgaria.Areas.Administration.Services.EditJobPosition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditJobPosition.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditJobPosition.ViewModels;
    using SharemundoBulgaria.Data;

    public class EditJobPositionService : IEditJobPositionService
    {
        private readonly ApplicationDbContext db;

        public EditJobPositionService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task EditJobPosition(EditJobPositionInputModel model)
        {
            var targetPosition = await this.db.JobPositions.FirstOrDefaultAsync(x => x.Id == model.Id);
            targetPosition.Title = model.Title;
            targetPosition.CreatedOn = DateTime.UtcNow;
            targetPosition.Location = model.Location;
            targetPosition.Description = model.SanitizeDescription;
            this.db.JobPositions.Update(targetPosition);
            await this.db.SaveChangesAsync();
        }

        public ICollection<EditJobPositionViewModel> GetAllJobsPositions()
        {
            var positions = this.db.JobPositions.ToList();
            var result = new List<EditJobPositionViewModel>();

            foreach (var position in positions)
            {
                result.Add(new EditJobPositionViewModel
                {
                    Id = position.Id,
                    Title = position.Title,
                });
            }

            return result;
        }

        public async Task<GetJobPositionDataViewModel> GetJobPositionById(string positionId)
        {
            var position = await this.db.JobPositions.FirstOrDefaultAsync(x => x.Id == positionId);
            return new GetJobPositionDataViewModel
            {
                Title = position.Title,
                Location = position.Location,
                Description = position.Description,
            };
        }
    }
}