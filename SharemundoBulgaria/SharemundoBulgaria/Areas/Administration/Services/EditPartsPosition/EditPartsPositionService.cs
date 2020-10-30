namespace SharemundoBulgaria.Areas.Administration.Services.EditPartsPosition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditPartsPosition.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditPartsPosition.ViewModels;
    using SharemundoBulgaria.Data;

    public class EditPartsPositionService : IEditPartsPositionService
    {
        private readonly ApplicationDbContext db;

        public EditPartsPositionService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<int> EditPartsPosition(EditPartsPositionInputModel[] allParts)
        {
            var count = 0;
            foreach (var part in allParts)
            {
                var targetPart = await this.db.SectionParts
                    .FirstOrDefaultAsync(x => x.Id == part.Id && x.Name == part.Name);
                if (targetPart.PositionNumber != part.PositionNumber)
                {
                    count++;
                }

                targetPart.PositionNumber = part.PositionNumber;
                this.db.SectionParts.Update(targetPart);
            }

            await this.db.SaveChangesAsync();
            return count;
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