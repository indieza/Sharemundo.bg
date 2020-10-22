﻿namespace SharemundoBulgaria.Models.Page
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;

    public class Section
    {
        public Section()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(25)]
        public string PageName { get; set; }

        [Required]
        public int PositionNumber { get; set; }

        [ForeignKey(nameof(PartText))]
        public string PartTextId { get; set; }

        public PartText PartText { get; set; }

        [ForeignKey(nameof(PartImage))]
        public string PartImageId { get; set; }

        public PartImage PartImage { get; set; }

        public ICollection<SectionPart> SectionParts { get; set; } = new HashSet<SectionPart>();
    }
}