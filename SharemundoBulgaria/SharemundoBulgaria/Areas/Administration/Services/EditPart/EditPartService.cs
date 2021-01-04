namespace SharemundoBulgaria.Areas.Administration.Services.EditPart
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using Microsoft.EntityFrameworkCore;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditPart.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditPart.ViewModels;
    using SharemundoBulgaria.Data;
    using SharemundoBulgaria.Models.Page;
    using SharemundoBulgaria.Services.Cloud;

    public class EditPartService : IEditPartService
    {
        private readonly ApplicationDbContext db;
        private readonly Cloudinary cloudinary;

        public EditPartService(ApplicationDbContext db, Cloudinary cloudinary)
        {
            this.db = db;
            this.cloudinary = cloudinary;
        }

        public async Task EditPart(EditPartInputModel model)
        {
            var part = await this.db.SectionParts.FirstOrDefaultAsync(x => x.Id == model.Id);
            var partText = await this.db.PartTexts.FirstOrDefaultAsync(x => x.SectionPartId == model.Id);
            var partImage = await this.db.PartImages.FirstOrDefaultAsync(x => x.SectionPartId == model.Id);

            part.Name = model.Name;

            if (partText == null && (model.Heading != null || model.Subheading != null || model.Description != null))
            {
                this.db.PartTexts.Add(new PartText
                {
                    SectionPartId = part.Id,
                    Heading = model.Heading,
                    HeadingBg = model.HeadingBg,
                    Subheading = model.Subheading,
                    SubheadingBg = model.SubheadingBg,
                    Description = model.SanitizeDescription,
                    DescriptionBg = model.DescriptionBg,
                });
            }

            if (partText != null)
            {
                partText.Heading = model.Heading;
                partText.HeadingBg = model.HeadingBg;
                partText.Subheading = model.Subheading;
                partText.SubheadingBg = model.SubheadingBg;
                partText.Description = model.SanitizeDescription;
                partText.DescriptionBg = model.SanitizeDescriptionBg;
                this.db.PartTexts.Update(partText);
            }

            if (partImage == null && model.Image != null)
            {
                var imageUrl = await ApplicationCloudinary.UploadImage(
                   this.cloudinary,
                   model.Image,
                   $"PartImage-{part.Id}");

                this.db.PartImages.Add(new PartImage
                {
                    SectionPartId = part.Id,
                    Name = $"PartImage-{part.Id}",
                    Url = imageUrl,
                });
            }

            if (partImage != null && model.Image != null)
            {
                var imageUrl = await ApplicationCloudinary.UploadImage(
                   this.cloudinary,
                   model.Image,
                   partImage.Name);
                partImage.Url = imageUrl;
                this.db.PartImages.Update(partImage);
            }

            await this.db.SaveChangesAsync();
        }

        public Dictionary<string, string> GetAllParts()
        {
            var parts = this.db.SectionParts.ToList();
            var result = new Dictionary<string, string>();

            foreach (var part in parts)
            {
                result.Add(part.Id, part.Name);
            }

            return result;
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

        public async Task<GetPartDataViewModel> GetPartById(string partId)
        {
            var part = await this.db.SectionParts.FirstOrDefaultAsync(x => x.Id == partId);
            var partText = await this.db.PartTexts.FirstOrDefaultAsync(x => x.SectionPartId == partId);

            return new GetPartDataViewModel
            {
                Name = part.Name,
                PartType = part.PartType,
                SectionId = part.SectionId,
                Heading = partText?.Heading,
                HeadingBg = partText?.HeadingBg,
                Subheading = partText?.Subheading,
                SubheadingBg = partText?.SubheadingBg,
                Description = partText?.Description,
                DescriptionBg = partText?.DescriptionBg,
            };
        }
    }
}