namespace SharemundoBulgaria.Areas.Administration.Services.RemoveSection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using Microsoft.EntityFrameworkCore;
    using SharemundoBulgaria.Data;
    using SharemundoBulgaria.Services.Cloud;

    public class RemoveSectionService : IRemoveSectionService
    {
        private readonly ApplicationDbContext db;
        private readonly Cloudinary cloudinary;

        public RemoveSectionService(ApplicationDbContext db, Cloudinary cloudinary)
        {
            this.db = db;
            this.cloudinary = cloudinary;
        }

        public Dictionary<string, string> GetAllSections()
        {
            var allSections = this.db.Sections.ToList();
            var result = new Dictionary<string, string>();

            foreach (var section in allSections)
            {
                result.Add(section.Id, section.Name);
            }

            return result;
        }

        public async Task<Tuple<string, int>> RemoveSection(string id)
        {
            var targetSection = await this.db.Sections.FirstOrDefaultAsync(x => x.Id == id);
            var targetParts = this.db.SectionParts.Where(x => x.SectionId == id).ToList();
            var targetTexts = this.db.PartTexts.Where(x => x.SectionId == id).ToList();
            var targetImages = this.db.PartImages.Where(x => x.SectionId == id).ToList();

            var removedParts = 0;
            var removedSectionName = targetSection.Name;

            this.db.PartTexts.RemoveRange(targetTexts);

            foreach (var targetPart in targetParts)
            {
                var partImages = this.db.PartImages.Where(x => x.SectionPartId == targetPart.Id).ToList();
                var partTexts = this.db.PartTexts.Where(x => x.SectionPartId == targetPart.Id).ToList();

                foreach (var partImage in partImages)
                {
                    ApplicationCloudinary.DeleteImage(this.cloudinary, partImage.Name);
                }

                this.db.PartImages.RemoveRange(partImages);
                this.db.PartTexts.RemoveRange(partTexts);
                this.db.SectionParts.Remove(targetPart);
                removedParts++;
            }

            foreach (var targetImage in targetImages)
            {
                ApplicationCloudinary.DeleteImage(this.cloudinary, targetImage.Name);
            }

            this.db.PartImages.RemoveRange(targetImages);
            this.db.Sections.Remove(targetSection);
            await this.db.SaveChangesAsync();

            return Tuple.Create(removedSectionName, removedParts);
        }
    }
}