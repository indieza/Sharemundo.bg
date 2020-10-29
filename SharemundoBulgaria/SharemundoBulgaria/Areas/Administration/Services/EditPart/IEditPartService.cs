namespace SharemundoBulgaria.Areas.Administration.Services.EditPart
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditPart.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditPart.ViewModels;

    public interface IEditPartService
    {
        Dictionary<string, string> GetAllParts();

        Dictionary<string, string> GetAllSections();

        Task<GetPartDataViewModel> GetPartById(string partId);

        Task EditPart(EditPartInputModel model);
    }
}