namespace SharemundoBulgaria.Areas.Administration.Services.RemovePart
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

    public class RemovePartService : IRemovePartService
    {
        private readonly ApplicationDbContext db;
        private readonly Cloudinary cloudinary;

        public RemovePartService(ApplicationDbContext db, Cloudinary cloudinary)
        {
            this.db = db;
            this.cloudinary = cloudinary;
        }

        public Dictionary<string, string> GetAllParts()
        {
            var allParts = this.db.SectionParts.ToList();
            var result = new Dictionary<string, string>();

            foreach (var part in allParts)
            {
                result.Add(part.Id, part.Name);
            }

            return result;
        }

        public async Task<string> RemovePart(string id)
        {
            var targetPart = await this.db.SectionParts.FirstOrDefaultAsync(x => x.Id == id);
            var removedSectionName = targetPart.Name;
            var targetTexts = this.db.PartTexts.Where(x => x.SectionPartId == id).ToList();
            var targetImages = this.db.PartImages.Where(x => x.SectionPartId == id);

            foreach (var targetImage in targetImages)
            {
                ApplicationCloudinary.DeleteImage(this.cloudinary, targetImage.Name);
                this.db.PartImages.Remove(targetImage);
            }

            this.db.PartTexts.RemoveRange(targetTexts);
            this.db.SectionParts.Remove(targetPart);
            await this.db.SaveChangesAsync();
            return removedSectionName;
        }
    }
}