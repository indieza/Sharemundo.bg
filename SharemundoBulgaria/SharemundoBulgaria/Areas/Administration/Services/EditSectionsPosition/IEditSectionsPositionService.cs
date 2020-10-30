namespace SharemundoBulgaria.Areas.Administration.Services.EditSectionsPosition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditSectionsPosition.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditSectionsPosition.ViewModels;

    public interface IEditSectionsPositionService
    {
        ICollection<GetSectionsPositionViewModel> GetSectionsPosition(int pageType);

        Task<int> EditSectionsPosition(EditSectionsPositionInputModel[] allSections);
    }
}