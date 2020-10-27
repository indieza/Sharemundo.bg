namespace SharemundoBulgaria.Models.Page
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Models.Enums;

    public class SectionPart
    {
        public SectionPart()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        public PartType PartType { get; set; }

        [Required]
        public int PositionNumber { get; set; }

        [ForeignKey(nameof(Page.Section))]
        [Required]
        public string SectionId { get; set; }

        public Section Section { get; set; }

        [ForeignKey(nameof(Page.PartText))]
        public string PartTextId { get; set; }

        public PartText PartText { get; set; }

        [ForeignKey(nameof(Page.PartImage))]
        public string PartImageId { get; set; }

        public PartImage PartImage { get; set; }
    }
}