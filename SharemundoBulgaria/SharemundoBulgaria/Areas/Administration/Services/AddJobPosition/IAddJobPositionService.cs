namespace SharemundoBulgaria.Areas.Administration.Services.AddJobPosition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddJobPosition.InputModels;

    public interface IAddJobPositionService
    {
        Task AddJobPosition(AddJobPositionInputModel model);
    }
}