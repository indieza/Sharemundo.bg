namespace SharemundoBulgaria.Models.User
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        [MaxLength(30)]
        public string CompanyName { get; set; }

        [MaxLength(30)]
        public string PositionInCompany { get; set; }

        [MaxLength(15)]
        public string FirstName { get; set; }

        [MaxLength(15)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string City { get; set; }

        [MaxLength(20)]
        public string Country { get; set; }

        public int PostCode { get; set; }

        [MaxLength(700)]
        public string AboutMe { get; set; }

        public bool IsBlocked { get; set; }

        public string ImageUrl { get; set; }
    }
}