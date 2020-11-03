namespace SharemundoBulgaria.Models.Job
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class JobPosition
    {
        public JobPosition()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Title { get; set; }

        [Required]
        [MaxLength(70)]
        public string Location { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<JobCandidate> JobCandidates { get; set; } = new HashSet<JobCandidate>();
    }
}