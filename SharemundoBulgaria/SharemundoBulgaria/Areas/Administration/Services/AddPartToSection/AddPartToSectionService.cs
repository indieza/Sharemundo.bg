namespace SharemundoBulgaria.Areas.Administration.Services.AddPartToSection
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using Microsoft.EntityFrameworkCore;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddPartToSection.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddPartToSection.ViewModels;
    using SharemundoBulgaria.Data;
    using SharemundoBulgaria.Models.Enums;
    using SharemundoBulgaria.Models.Page;
    using SharemundoBulgaria.Services.Cloud;

    public class AddPartToSectionService : IAddPartToSectionService
    {
        private readonly ApplicationDbContext db;
        private readonly Cloudinary cloudinary;

        public AddPartToSectionService(ApplicationDbContext db, Cloudinary cloudinary)
        {
            this.db = db;
            this.cloudinary = cloudinary;
        }

        public async Task<string> AddPartToSection(AddPartToSectionInputModel model)
        {
            var sectionName = await this.db.Sections
                .Where(x => x.Id == model.SectionId)
                .Select(x => x.Name)
                .FirstOrDefaultAsync();

            int? lastPartPositionNumber = await this.db.SectionParts
                .Where(x => x.SectionId == model.SectionId)
                .OrderByDescending(x => x.PositionNumber)
                .Select(x => x.PositionNumber)
                .FirstOrDefaultAsync();

            var part = new SectionPart
            {
                Name = model.Name,
                SectionId = model.SectionId,
                PartType = model.PartType,
                PositionNumber = lastPartPositionNumber == null ? 0 : (int)lastPartPositionNumber + 1,
            };

            if (model.Heading != null || model.Subheading != null || model.Description != null)
            {
                part.PartText = new PartText
                {
                    Heading = model.Heading,
                    Subheading = model.Subheading,
                    Description = model.SanitizeDescription,
                    SectionPartId = part.Id,
                };
            }

            if (model.Image != null)
            {
                var imageUrl = await ApplicationCloudinary.UploadImage(
                this.cloudinary,
                model.Image,
                $"PartImage-{part.Id}");

                part.PartImage = new PartImage
                {
                    Name = $"PartImage-{part.Id}",
                    SectionPartId = part.Id,
                    Url = imageUrl,
                };
            }

            this.db.SectionParts.Add(part);
            await this.db.SaveChangesAsync();
            return sectionName;
        }

        public Dictionary<string, PartType> GetAllElements(string path)
        {
            var elements = new Dictionary<string, PartType>();
            var fileNames = new DirectoryInfo(path).GetFiles().Select(x => x.Name).ToList();

            var allEnums = Enum.GetValues(typeof(PartType));

            foreach (var currentEnum in allEnums)
            {
                if (fileNames.Any(x => x.Contains(currentEnum.ToString())))
                {
                    elements.Add(
                        fileNames.FirstOrDefault(x => x.Contains(currentEnum.ToString())).ToString(),
                        (PartType)Enum.Parse(typeof(PartType), currentEnum.ToString()));
                }
            }

            return elements;
        }

        public Dictionary<string, string> GetAllSections()
        {
            var sections = this.db.Sections.ToList();
            var allSections = new Dictionary<string, string>();

            foreach (var section in sections)
            {
                allSections.Add(section.Id, section.Name);
            }

            return allSections;
        }
    }
}