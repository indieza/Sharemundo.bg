namespace SharemundoBulgaria.Models.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationRole : IdentityRole
    {
        public int RoleLevel { get; set; }
    }
}