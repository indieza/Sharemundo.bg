namespace SharemundoBulgaria.Areas.Administration.Services.RemoveJobPosition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.RemoveJobPosition.ViewModels;

    public interface IRemoveJobService
    {
        ICollection<RemoveJobPositionViewModel> GetAllJobsPositions();

        Task DeleteJobPosition(string id);
    }
}