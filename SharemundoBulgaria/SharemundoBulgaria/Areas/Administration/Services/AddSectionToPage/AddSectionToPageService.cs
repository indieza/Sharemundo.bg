﻿namespace SharemundoBulgaria.Areas.Administration.Services.AddSectionToPage
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using Microsoft.EntityFrameworkCore;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddSectionToPage.InputModels;
    using SharemundoBulgaria.Data;
    using SharemundoBulgaria.Models.Enums;
    using SharemundoBulgaria.Models.Page;
    using SharemundoBulgaria.Services.Cloud;

    public class AddSectionToPageService : IAddSectionToPageService
    {
        private readonly ApplicationDbContext db;
        private readonly Cloudinary cloudinary;

        public AddSectionToPageService(ApplicationDbContext db, Cloudinary cloudinary)
        {
            this.db = db;
            this.cloudinary = cloudinary;
        }

        public async Task AddSectionToPage(AddSectionToPageInputModel model)
        {
            int? lastSectionPositionNumber = await this.db.Sections
                .OrderByDescending(x => x.PositionNumber)
                .Select(x => x.PositionNumber)
                .FirstOrDefaultAsync();

            var section = new Section
            {
                SectionType = model.SectionType,
                PageType = model.PageType,
                Name = model.Name,
                PositionNumber = lastSectionPositionNumber == null ? 0 : (int)lastSectionPositionNumber + 1,
            };

            if (model.Heading != null || model.Subheading != null || model.Description != null)
            {
                section.PartText = new PartText
                {
                    Heading = model.Heading,
                    HeadingBg = model.HeadingBg,
                    Subheading = model.Subheading,
                    SubheadingBg = model.SubheadingBg,
                    Description = model.SanitizeDescription,
                    DescriptionBg = model.SanitizeDescriptionBg,
                    SectionId = section.Id,
                };
            }

            if (model.Image != null)
            {
                var imageUrl = await ApplicationCloudinary.UploadImage(
                this.cloudinary,
                model.Image,
                $"SectionImage-{section.Id}");

                section.PartImage = new PartImage
                {
                    Name = $"SectionImage-{section.Id}",
                    SectionId = section.Id,
                    Url = imageUrl,
                };
            }

            this.db.Sections.Add(section);
            await this.db.SaveChangesAsync();
        }

        public Dictionary<string, SectionType> GetAllElements(string path)
        {
            var elements = new Dictionary<string, SectionType>();
            var fileNames = new DirectoryInfo(path).GetFiles().Select(x => x.Name).ToList();

            var allEnums = Enum.GetValues(typeof(SectionType));

            foreach (var currentEnum in allEnums)
            {
                if (fileNames.Any(x => x.Contains(currentEnum.ToString())))
                {
                    elements.Add(
                        fileNames.FirstOrDefault(x => x.Contains(currentEnum.ToString())).ToString(),
                        (SectionType)Enum.Parse(typeof(SectionType), currentEnum.ToString()));
                }
            }

            return elements;
        }
    }
}