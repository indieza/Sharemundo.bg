namespace SharemundoBulgaria.Models.Job
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;

    public class JobCandidate
    {
        public JobCandidate()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(12)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(12)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phonenumber { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(80)]
        public string Email { get; set; }

        [Required]
        public string CvUrl { get; set; }

        [ForeignKey(nameof(JobPosition))]
        [Required]
        public string JobPositionId { get; set; }

        public JobPosition JobPosition { get; set; }
    }
}