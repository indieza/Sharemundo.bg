namespace SharemundoBulgaria.Areas.Administration.ViewModels.RemoveJobPosition.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.RemoveJobPosition.InputModels;

    public class RemoveJobPositionBaseModel
    {
        public ICollection<RemoveJobPositionViewModel> AllJobsPositions { get; set; } =
            new HashSet<RemoveJobPositionViewModel>();

        public RemoveJobPositionInputModel RemoveJobPositionInputModel { get; set; } =
            new RemoveJobPositionInputModel();
    }
}