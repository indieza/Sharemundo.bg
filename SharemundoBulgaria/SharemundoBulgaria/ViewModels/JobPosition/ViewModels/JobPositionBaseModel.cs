namespace SharemundoBulgaria.ViewModels.JobPosition.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.ViewModels.JobPosition.InputModels;

    public class JobPositionBaseModel
    {
        public JobPositionViewModel JobPositionViewModel { get; set; } = new JobPositionViewModel();

        public JobCandidateInputModel JobCandidateInputModel { get; set; } = new JobCandidateInputModel();
    }
}