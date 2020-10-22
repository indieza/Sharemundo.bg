namespace SharemundoBulgaria.Models.Page
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;

    public class PartImage
    {
        public PartImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(Section))]
        public string SectionId { get; set; }

        public Section Section { get; set; }

        [ForeignKey(nameof(SectionPart))]
        public string SectionPartId { get; set; }

        public SectionPart SectionPart { get; set; }
    }
}