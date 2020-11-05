namespace SharemundoBulgaria.Areas.Administration.Services.RemoveJobPosition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using Microsoft.EntityFrameworkCore;
    using SharemundoBulgaria.Areas.Administration.ViewModels.RemoveJobPosition.ViewModels;
    using SharemundoBulgaria.Data;
    using SharemundoBulgaria.Services.Cloud;

    public class RemoveJobService : IRemoveJobService
    {
        private readonly ApplicationDbContext db;
        private readonly Cloudinary cloudinary;

        public RemoveJobService(ApplicationDbContext db, Cloudinary cloudinary)
        {
            this.db = db;
            this.cloudinary = cloudinary;
        }

        public async Task DeleteJobPosition(string id)
        {
            var position = await this.db.JobPositions.FirstOrDefaultAsync(x => x.Id == id);
            var positionCandidates = this.db.JobCandidates.Where(x => x.JobPositionId == id).ToList();

            foreach (var candidate in positionCandidates)
            {
                ApplicationCloudinary.DeleteImage(this.cloudinary, candidate.CvName);
            }

            this.db.JobCandidates.RemoveRange(positionCandidates);
            this.db.JobPositions.Remove(position);
            await this.db.SaveChangesAsync();
        }

        public ICollection<RemoveJobPositionViewModel> GetAllJobsPositions()
        {
            var allPositions = this.db.JobPositions.ToList();
            var result = new List<RemoveJobPositionViewModel>();

            foreach (var position in allPositions)
            {
                result.Add(new RemoveJobPositionViewModel
                {
                    Id = position.Id,
                    Title = position.Title,
                });
            }

            return result;
        }
    }
}