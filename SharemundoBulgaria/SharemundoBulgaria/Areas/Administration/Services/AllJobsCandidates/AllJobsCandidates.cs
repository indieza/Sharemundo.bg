namespace SharemundoBulgaria.Areas.Administration.Services.AllJobsCandidates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using Microsoft.EntityFrameworkCore;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AllJobsCandidates.ViewModels;
    using SharemundoBulgaria.Data;
    using SharemundoBulgaria.Services.Cloud;

    public class AllJobsCandidates : IAllJobsCandidates
    {
        private readonly ApplicationDbContext db;
        private readonly Cloudinary cloudinary;

        public AllJobsCandidates(ApplicationDbContext db, Cloudinary cloudinary)
        {
            this.db = db;
            this.cloudinary = cloudinary;
        }

        public async Task DeleteCandidate(string id)
        {
            var targetCandidate = await this.db.JobCandidates.FirstOrDefaultAsync(x => x.Id == id);
            ApplicationCloudinary.DeleteImage(this.cloudinary, targetCandidate.CvName);
            this.db.JobCandidates.Remove(targetCandidate);
            await this.db.SaveChangesAsync();
        }

        public ICollection<JobCandidateViewModel> GetAllCandidates()
        {
            var candidates = this.db.JobCandidates.ToList();
            var result = new List<JobCandidateViewModel>();

            foreach (var candidate in candidates)
            {
                result.Add(new JobCandidateViewModel
                {
                    JobCandidateId = candidate.Id,
                    JobPositionId = candidate.JobPositionId,
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    Email = candidate.Email,
                    Phonenumber = candidate.Phonenumber,
                    JobTitle = this.db.JobPositions
                    .Where(x => x.Id == candidate.JobPositionId)
                    .Select(x => x.Title).FirstOrDefault(),
                    CvUrl = candidate.CvUrl,
                });
            }

            return result;
        }
    }
}