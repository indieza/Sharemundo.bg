namespace SharemundoBulgaria.Services.Career
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.ViewModels.JobPosition.ViewModels;

    public interface ICareerService
    {
        ICollection<JobPositionViewModel> GetAllJobsPositions();
    }
}