namespace SharemundoBulgaria.Areas.Administration.Services.AllJobsCandidates
{
    using SharemundoBulgaria.Areas.Administration.ViewModels.AllJobsCandidates.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAllJobsCandidates
    {
        ICollection<JobCandidateViewModel> GetAllCandidates();

        Task DeleteCandidate(string id);
    }
}