namespace SharemundoBulgaria.Services.Career
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using SharemundoBulgaria.Data;
    using SharemundoBulgaria.ViewModels.JobPosition.ViewModels;

    public class CareerService : ICareerService
    {
        private readonly ApplicationDbContext db;

        public CareerService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ICollection<JobPositionViewModel> GetAllJobsPositions()
        {
            var allPositions = this.db.JobPositions.ToList();
            var result = new List<JobPositionViewModel>();

            foreach (var position in allPositions)
            {
                var contentWithoutTags = Regex.Replace(position.Description, "<.*?>", string.Empty);
                result.Add(new JobPositionViewModel
                {
                    Id = position.Id,
                    Title = position.Title,
                    Location = position.Location,
                    CreatedOn = position.CreatedOn,
                    Description = contentWithoutTags.Length <= 600 ?
                    contentWithoutTags :
                    $"{contentWithoutTags.Substring(0, 600)}...",
                });
            }

            return result;
        }

        public async Task<JobPositionViewModel> GetJobById(string id)
        {
            var job = await this.db.JobPositions.FirstOrDefaultAsync(x => x.Id == id);
            return new JobPositionViewModel
            {
                Id = job.Id,
                Title = job.Title,
                CreatedOn = job.CreatedOn,
                Description = job.Description,
                Location = job.Location,
            };
        }
    }
}