namespace SharemundoBulgaria.Areas.Administration.Services.AllJobsCandidates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AllJobsCandidates.ViewModels;
    using SharemundoBulgaria.Data;

    public class AllJobsCandidates : IAllJobsCandidates
    {
        private readonly ApplicationDbContext db;

        public AllJobsCandidates(ApplicationDbContext db)
        {
            this.db = db;
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