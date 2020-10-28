namespace SharemundoBulgaria.Areas.Administration.Services.RemoveSection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRemoveSectionService
    {
        Dictionary<string, string> GetAllSections();

        Task<Tuple<string, int>> RemoveSection(string id);
    }
}