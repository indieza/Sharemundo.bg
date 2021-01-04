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
            targetPosition.TitleBg = model.TitleBg;
            targetPosition.CreatedOn = DateTime.UtcNow;
            targetPosition.Location = model.Location;
            targetPosition.LocationBg = model.LocationBg;
            targetPosition.Description = model.SanitizeDescription;
            targetPosition.DescriptionBg = model.SanitizeDescriptionBg;
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
                TitleBg = position.TitleBg,
                Location = position.Location,
                LocationBg = position.LocationBg,
                Description = position.Description,
                DescriptionBg = position.DescriptionBg,
            };
        }
    }
}