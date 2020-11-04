namespace SharemundoBulgaria.Data
{
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SharemundoBulgaria.Models.Job;
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

        public DbSet<JobPosition> JobPositions { get; set; }

        public DbSet<JobCandidate> JobCandidates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PartText>()
                .HasOne(x => x.Section)
                .WithOne(x => x.PartText)
                .HasForeignKey<PartText>(x => x.SectionId);

            builder.Entity<PartText>()
                .HasOne<SectionPart>(x => x.SectionPart)
                .WithOne(x => x.PartText)
                .HasForeignKey<PartText>(x => x.SectionPartId);

            builder.Entity<PartImage>()
                .HasOne(x => x.Section)
                .WithOne(x => x.PartImage)
                .HasForeignKey<PartImage>(x => x.SectionId);

            builder.Entity<PartImage>()
                .HasOne(x => x.SectionPart)
                .WithOne(x => x.PartImage)
                .HasForeignKey<PartImage>(x => x.SectionPartId);

            builder.Entity<Section>()
                .HasOne(x => x.PartText)
                .WithOne(x => x.Section)
                .HasForeignKey<Section>(x => x.PartTextId);

            builder.Entity<Section>()
                .HasOne(x => x.PartImage)
                .WithOne(x => x.Section)
                .HasForeignKey<Section>(x => x.PartImageId);

            builder.Entity<SectionPart>()
               .HasOne(x => x.PartText)
               .WithOne(x => x.SectionPart)
               .HasForeignKey<SectionPart>(x => x.PartTextId);

            builder.Entity<SectionPart>()
               .HasOne(x => x.PartImage)
               .WithOne(x => x.SectionPart)
               .HasForeignKey<SectionPart>(x => x.PartImageId);

            builder.Entity<Section>()
               .HasMany(x => x.SectionParts)
               .WithOne(x => x.Section)
               .HasForeignKey(x => x.SectionId);

            builder.Entity<SectionPart>()
                .HasOne(x => x.Section)
                .WithMany(x => x.SectionParts)
                .HasForeignKey(x => x.SectionId);

            builder.Entity<JobPosition>()
                .HasMany(x => x.JobCandidates)
                .WithOne(x => x.JobPosition)
                .HasForeignKey(x => x.JobPositionId);

            base.OnModelCreating(builder);
        }
    }
}