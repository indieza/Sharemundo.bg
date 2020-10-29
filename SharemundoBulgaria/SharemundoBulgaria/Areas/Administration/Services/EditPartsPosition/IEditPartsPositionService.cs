namespace SharemundoBulgaria.Areas.Administration.Services.EditPartsPosition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditPartsPosition.ViewModels;

    public interface IEditPartsPositionService
    {
        ICollection<GetPartsPositionViewModel> GetPartsPosition(string sectionId);

        Dictionary<string, string> GetAllSections();
    }
}