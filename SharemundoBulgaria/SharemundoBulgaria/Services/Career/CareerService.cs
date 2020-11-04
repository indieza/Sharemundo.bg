namespace SharemundoBulgaria.Services.Career
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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
                result.Add(new JobPositionViewModel
                {
                    Title = position.Title,
                    Location = position.Location,
                    CreatedOn = position.CreatedOn,
                    Description = position.Description,
                });
            }

            return result;
        }
    }
}