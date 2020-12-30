namespace SharemundoBulgaria.Models.Page
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

        public string HeadingBg { get; set; }

        public string Subheading { get; set; }

        public string SubheadingBg { get; set; }

        public string Description { get; set; }

        public string DescriptionBg { get; set; }

        [ForeignKey(nameof(Page.Section))]
        public string SectionId { get; set; }

        public Section Section { get; set; }

        [ForeignKey(nameof(Page.SectionPart))]
        public string SectionPartId { get; set; }

        public SectionPart SectionPart { get; set; }
    }
}