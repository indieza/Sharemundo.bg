﻿namespace SharemundoBulgaria.Models.Page
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;

    public class PartText
    {
        public PartText()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        public string Heading { get; set; }

        public string Subheading { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(Section))]
        public string SectionId { get; set; }

        public Section Section { get; set; }

        [ForeignKey(nameof(SectionPart))]
        public string SectionPartId { get; set; }

        public SectionPart SectionPart { get; set; }
    }
}