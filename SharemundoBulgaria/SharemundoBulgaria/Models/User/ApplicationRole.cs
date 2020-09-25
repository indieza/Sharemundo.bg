namespace SharemundoBulgaria.Models.User
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationRole : IdentityRole
    {
        public int RoleLevel { get; set; }
    }
}