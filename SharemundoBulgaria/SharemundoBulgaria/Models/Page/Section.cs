namespace SharemundoBulgaria.Models.Page
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
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

        public ICollection<SectionText> SectionTexts { get; set; } = new HashSet<SectionText>();

        public ICollection<SectionImage> SectionImages { get; set; } = new HashSet<SectionImage>();
    }
}