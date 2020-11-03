namespace SharemundoBulgaria.Areas.Administration.Services.AddJobPosition
{
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddJobPosition.InputModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAddJobPositionService
    {
        Task AddJobPosition(AddJobPositionInputModel model);
    }
}