namespace SharemundoBulgaria.Areas.Administration.Services.EditSection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using Microsoft.EntityFrameworkCore;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditSection.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditSection.ViewModels;
    using SharemundoBulgaria.Data;
    using SharemundoBulgaria.Models.Page;
    using SharemundoBulgaria.Services.Cloud;

    public class EditSectionService : IEditSectionService
    {
        private readonly ApplicationDbContext db;
        private readonly Cloudinary cloudinary;

        public EditSectionService(ApplicationDbContext db, Cloudinary cloudinary)
        {
            this.db = db;
            this.cloudinary = cloudinary;
        }

        public async Task EditSection(EditSectionInputModel model)
        {
            var section = await this.db.Sections.FirstOrDefaultAsync(x => x.Id == model.Id);
            var sectionText = await this.db.PartTexts
                .FirstOrDefaultAsync(x => x.SectionId == model.Id);
            var sectionImage = await this.db.PartImages
                .FirstOrDefaultAsync(x => x.SectionId == model.Id);

            section.Name = model.Name;

            if (sectionText == null && (model.Heading != null || model.Subheading != null || model.Description != null))
            {
                this.db.PartTexts.Add(new PartText
                {
                    SectionId = section.Id,
                    Heading = model.Heading,
                    HeadingBg = model.HeadingBg,
                    Subheading = model.Subheading,
                    SubheadingBg = model.SubheadingBg,
                    Description = model.SanitizeDescription,
                    DescriptionBg = model.SanitizeDescriptionBg,
                });
            }

            if (sectionText != null)
            {
                sectionText.Heading = model.Heading;
                sectionText.HeadingBg = model.HeadingBg;
                sectionText.Subheading = model.Subheading;
                sectionText.SubheadingBg = model.SubheadingBg;
                sectionText.Description = model.SanitizeDescription;
                sectionText.DescriptionBg = model.DescriptionBg;
                this.db.PartTexts.Update(sectionText);
            }

            if (sectionImage == null && model.Image != null)
            {
                var imageUrl = await ApplicationCloudinary.UploadImage(
                   this.cloudinary,
                   model.Image,
                   $"SectionImage-{section.Id}");

                this.db.PartImages.Add(new PartImage
                {
                    SectionId = section.Id,
                    Name = $"SectionImage-{section.Id}",
                    Url = imageUrl,
                });
            }

            if (sectionImage != null && model.Image != null)
            {
                var imageUrl = await ApplicationCloudinary.UploadImage(
                   this.cloudinary,
                   model.Image,
                   sectionImage.Name);
                sectionImage.Url = imageUrl;
                this.db.PartImages.Update(sectionImage);
            }

            await this.db.SaveChangesAsync();
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

        public async Task<GetSectionDataViewModel> GetSectionById(string sectionId)
        {
            var section = await this.db.Sections.FirstOrDefaultAsync(x => x.Id == sectionId);
            var sectionText = await this.db.PartTexts.FirstOrDefaultAsync(x => x.SectionId == sectionId);
            return new GetSectionDataViewModel
            {
                Name = section.Name,
                PageType = section.PageType,
                SectionType = section.SectionType,
                Heading = sectionText?.Heading,
                HeadingBg = sectionText?.HeadingBg,
                Subheading = sectionText?.Subheading,
                SubheadingBg = sectionText?.SubheadingBg,
                Description = sectionText?.Description,
                DescriptionBg = sectionText?.DescriptionBg,
            };
        }
    }
}