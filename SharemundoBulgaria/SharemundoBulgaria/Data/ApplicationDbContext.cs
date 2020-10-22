namespace SharemundoBulgaria.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SharemundoBulgaria.Models.Page;
    using SharemundoBulgaria.Models.User;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Section> Sections { get; set; }

        public DbSet<SectionPart> SectionParts { get; set; }

        public DbSet<PartText> PartTexts { get; set; }

        public DbSet<PartImage> PartImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}