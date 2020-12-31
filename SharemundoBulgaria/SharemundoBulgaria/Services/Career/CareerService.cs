namespace SharemundoBulgaria.Services.Career
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using Microsoft.EntityFrameworkCore;
    using SharemundoBulgaria.Data;
    using SharemundoBulgaria.Models.Job;
    using SharemundoBulgaria.Services.Cloud;
    using SharemundoBulgaria.ViewModels.JobPosition.InputModels;
    using SharemundoBulgaria.ViewModels.JobPosition.ViewModels;

    public class CareerService : ICareerService
    {
        private readonly ApplicationDbContext db;
        private readonly Cloudinary cloudinary;

        public CareerService(ApplicationDbContext db, Cloudinary cloudinary)
        {
            this.db = db;
            this.cloudinary = cloudinary;
        }

        public async Task ApplyForJob(JobCandidateInputModel model)
        {
            var isExist = await this.db.JobCandidates
                .FirstOrDefaultAsync(x => x.Phonenumber == model.Phonenumber &&
                x.Email == model.Email &&
                x.JobPositionId == model.JobPositionId);

            if (isExist == null)
            {
                isExist = new JobCandidate
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phonenumber = model.Phonenumber,
                    JobPositionId = model.JobPositionId,
                };

                var cvUrl = await ApplicationCloudinary.UploadImage(
                       this.cloudinary,
                       model.CV,
                       $"{isExist.Id}-{model.CV.FileName}");
                isExist.CvUrl = cvUrl;
                isExist.CvName = $"{isExist.Id}-{model.CV.FileName}";
                this.db.JobCandidates.Add(isExist);
            }
            else
            {
                isExist.FirstName = model.FirstName;
                isExist.LastName = model.LastName;
                ApplicationCloudinary.DeleteImage(this.cloudinary, isExist.CvName);
                var cvUrl = await ApplicationCloudinary.UploadImage(
                       this.cloudinary,
                       model.CV,
                       $"{isExist.Id}-{model.CV.FileName}");
                isExist.CvUrl = cvUrl;
                isExist.CvName = $"{isExist.Id}-{model.CV.FileName}";
                this.db.JobCandidates.Update(isExist);
            }

            await this.db.SaveChangesAsync();
        }

        public ICollection<JobPositionViewModel> GetAllJobsPositions(string culture)
        {
            var allPositions = this.db.JobPositions.ToList();
            var result = new List<JobPositionViewModel>();

            foreach (var position in allPositions)
            {
                var contentWithoutTags = Regex
                    .Replace(
                    culture.ToUpper() == "BG" ? position.DescriptionBg : position.Description,
                    "<.*?>",
                    string.Empty);
                result.Add(new JobPositionViewModel
                {
                    Id = position.Id,
                    Title = culture.ToUpper() == "BG" ? position.TitleBg : position.Title,
                    Location = culture.ToUpper() == "BG" ? position.LocationBg : position.Location,
                    CreatedOn = position.CreatedOn,
                    Description = contentWithoutTags.Length <= 600 ?
                    contentWithoutTags :
                    $"{contentWithoutTags.Substring(0, 600)}...",
                    JobCandidatesCount = this.db.JobCandidates.Count(x => x.JobPositionId == position.Id),
                });
            }

            return result;
        }

        public async Task<JobPositionViewModel> GetJobById(string id, string culture)
        {
            var job = await this.db.JobPositions.FirstOrDefaultAsync(x => x.Id == id);
            return new JobPositionViewModel
            {
                Id = job.Id,
                Title = culture.ToUpper() == "BG" ? job.TitleBg : job.Title,
                CreatedOn = job.CreatedOn,
                Description = culture.ToUpper() == "BG" ? job.DescriptionBg : job.Description,
                Location = culture.ToUpper() == "BG" ? job.LocationBg : job.Location,
                JobCandidatesCount = await this.db.JobCandidates.CountAsync(x => x.JobPositionId == id),
            };
        }
    }
}