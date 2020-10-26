namespace SharemundoBulgaria.Models.Page
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Models.Enums;

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
        public SectionType SectionType { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public PageType PageType { get; set; }

        [Required]
        public int PositionNumber { get; set; }

        [ForeignKey(nameof(Page.PartText))]
        public string PartTextId { get; set; }

        public PartText PartText { get; set; }

        [ForeignKey(nameof(Page.PartImage))]
        public string PartImageId { get; set; }

        public PartImage PartImage { get; set; }

        public ICollection<SectionPart> SectionParts { get; set; } = new HashSet<SectionPart>();
    }
}