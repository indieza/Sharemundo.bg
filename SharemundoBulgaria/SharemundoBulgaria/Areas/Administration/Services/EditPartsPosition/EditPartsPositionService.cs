namespace SharemundoBulgaria.Areas.Administration.Services.EditPartsPosition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditPartsPosition.ViewModels;
    using SharemundoBulgaria.Data;

    public class EditPartsPositionService : IEditPartsPositionService
    {
        private readonly ApplicationDbContext db;

        public EditPartsPositionService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Dictionary<string, string> GetAllSections()
        {
            var sections = this.db.Sections.ToList();
            var result = new Dictionary<string, string>();

            foreach (var section in sections)
            {
                result.Add(section.Id, section.Name);
            }

            return result;
        }

        public ICollection<GetPartsPositionViewModel> GetPartsPosition(string sectionId)
        {
            var parts = this.db.SectionParts.Where(x => x.SectionId == sectionId).ToList();
            var result = new List<GetPartsPositionViewModel>();

            foreach (var part in parts)
            {
                result.Add(new GetPartsPositionViewModel
                {
                    Id = part.Id,
                    Name = part.Name,
                    PositionNumber = part.PositionNumber,
                });
            }

            return result;
        }
    }
}