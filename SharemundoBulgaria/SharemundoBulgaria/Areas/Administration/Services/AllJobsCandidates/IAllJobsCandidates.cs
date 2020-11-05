namespace SharemundoBulgaria.Areas.Administration.Services.AllJobsCandidates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AllJobsCandidates.ViewModels;

    public interface IAllJobsCandidates
    {
        ICollection<JobCandidateViewModel> GetAllCandidates();

        Task DeleteCandidate(string id);
    }
}