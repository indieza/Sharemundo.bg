namespace SharemundoBulgaria.Services.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using SharemundoBulgaria.Data;
    using SharemundoBulgaria.Models.Enums;
    using SharemundoBulgaria.ViewModels.Section;
    using SharemundoBulgaria.ViewModels.SectionPart;

    public class ServicesService : IServicesService
    {
        private readonly ApplicationDbContext db;

        public ServicesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<ICollection<SectionViewModel>> GetAllServicesSections(string culture)
        {
            var allSections = this.db.Sections
                .Where(x => x.PageType == PageType.SERVICES)
                .OrderBy(x => x.PositionNumber)
                .ToList();
            var result = new List<SectionViewModel>();

            foreach (var section in allSections)
            {
                var allParts = this.db.SectionParts
                    .Where(x => x.SectionId == section.Id)
                    .OrderBy(x => x.PositionNumber)
                    .ToList();
                var sectionText = await this.db.PartTexts.FirstOrDefaultAsync(x => x.SectionId == section.Id);
                var sectionImage = await this.db.PartImages.FirstOrDefaultAsync(x => x.SectionId == section.Id);
                var currentSection = new SectionViewModel
                {
                    Id = section.Id,
                    Name = section.Name,
                    SectionType = section.SectionType,
                    Heading = culture.ToUpper() == "BG" ? sectionText?.HeadingBg : sectionText?.Heading,
                    Subheading = culture.ToUpper() == "BG" ? sectionText?.SubheadingBg : sectionText?.Subheading,
                    Description = culture.ToUpper() == "BG" ? sectionText?.DescriptionBg : sectionText?.Description,
                    Url = sectionImage?.Url,
                };

                foreach (var part in allParts)
                {
                    var partText = await this.db.PartTexts
                        .FirstOrDefaultAsync(x => x.SectionPartId == part.Id);
                    var partImage = await this.db.PartImages
                        .FirstOrDefaultAsync(x => x.SectionPartId == part.Id);

                    currentSection.AllParts.Add(new SectionPartViewModel
                    {
                        Id = part.Id,
                        Name = part.Name,
                        PartType = part.PartType,
                        Heading = culture.ToUpper() == "BG" ? partText?.HeadingBg : partText?.Heading,
                        Subheading = culture.ToUpper() == "BG" ? partText?.SubheadingBg : partText?.Subheading,
                        Description = culture.ToUpper() == "BG" ? partText?.DescriptionBg : partText?.Description,
                        Url = partImage?.Url,
                    });
                }

                result.Add(currentSection);
            }

            return result;
        }
    }
}