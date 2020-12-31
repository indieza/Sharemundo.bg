namespace SharemundoBulgaria.Services.Career
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.ViewModels.JobPosition.InputModels;
    using SharemundoBulgaria.ViewModels.JobPosition.ViewModels;

    public interface ICareerService
    {
        ICollection<JobPositionViewModel> GetAllJobsPositions(string culture);

        Task<JobPositionViewModel> GetJobById(string id, string culture);

        Task ApplyForJob(JobCandidateInputModel model);
    }
}