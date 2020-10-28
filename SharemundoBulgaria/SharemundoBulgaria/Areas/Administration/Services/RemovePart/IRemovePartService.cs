namespace SharemundoBulgaria.Areas.Administration.Services.RemovePart
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRemovePartService
    {
        Dictionary<string, string> GetAllParts();

        Task<string> RemovePart(string id);
    }
}