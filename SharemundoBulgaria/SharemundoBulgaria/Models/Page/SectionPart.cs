namespace SharemundoBulgaria.Models.Page
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;

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
        public string Name { get; set; }

        [Required]
        public int PositionNumber { get; set; }

        [ForeignKey(nameof(Section))]
        [Required]
        public string SectionId { get; set; }

        public Section Section { get; set; }

        [ForeignKey(nameof(PartText))]
        public string PartTextId { get; set; }

        public PartText PartText { get; set; }

        [ForeignKey(nameof(PartImage))]
        public string PartImageId { get; set; }

        public PartImage PartImage { get; set; }
    }
}