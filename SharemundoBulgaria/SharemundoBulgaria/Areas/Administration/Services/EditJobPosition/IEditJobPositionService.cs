namespace SharemundoBulgaria.Areas.Administration.Services.EditJobPosition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditJobPosition.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditJobPosition.ViewModels;

    public interface IEditJobPositionService
    {
        ICollection<EditJobPositionViewModel> GetAllJobsPositions();

        Task<GetJobPositionDataViewModel> GetJobPositionById(string positionId);

        Task EditJobPosition(EditJobPositionInputModel model);
    }
}