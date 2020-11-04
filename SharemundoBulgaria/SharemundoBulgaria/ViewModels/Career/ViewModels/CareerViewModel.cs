namespace SharemundoBulgaria.ViewModels.Career.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.ViewModels.JobPosition.ViewModels;

    public class CareerViewModel
    {
        public ICollection<JobPositionViewModel> JobPositionViewModels { get; set; } = new HashSet<JobPositionViewModel>();
    }
}