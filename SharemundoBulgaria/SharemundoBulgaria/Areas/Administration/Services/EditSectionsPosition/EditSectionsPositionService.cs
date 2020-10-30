namespace SharemundoBulgaria.Areas.Administration.Services.EditSectionsPosition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditSectionsPosition.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditSectionsPosition.ViewModels;
    using SharemundoBulgaria.Data;
    using SharemundoBulgaria.Models.Enums;

    public class EditSectionsPositionService : IEditSectionsPositionService
    {
        private readonly ApplicationDbContext db;

        public EditSectionsPositionService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<int> EditSectionsPosition(EditSectionsPositionInputModel[] allSections)
        {
            var count = 0;
            foreach (var section in allSections)
            {
                var targetSection = await this.db.Sections
                    .FirstOrDefaultAsync(x => x.Id == section.Id && x.Name == section.Name);
                if (targetSection.PositionNumber != section.PositionNumber)
                {
                    count++;
                }

                targetSection.PositionNumber = section.PositionNumber;
                this.db.Sections.Update(targetSection);
            }

            await this.db.SaveChangesAsync();
            return count;
        }

        public ICollection<GetSectionsPositionViewModel> GetSectionsPosition(int pageType)
        {
            var sections = this.db.Sections.Where(x => x.PageType == (PageType)pageType).ToList();
            var result = new List<GetSectionsPositionViewModel>();

            foreach (var section in sections)
            {
                result.Add(new GetSectionsPositionViewModel
                {
                    Id = section.Id,
                    Name = section.Name,
                    PositionNumber = section.PositionNumber,
                });
            }

            return result;
        }
    }
}