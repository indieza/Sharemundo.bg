namespace SharemundoBulgaria.Models.Page
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class SectionImage
    {
        public SectionImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }
    }
}