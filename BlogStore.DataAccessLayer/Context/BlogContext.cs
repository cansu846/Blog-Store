using BlogStore.EnitityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlogStore.DataAccessLayer.Context
{
    public class BlogContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer("Server=DESKTOP-3ADO5MC\\SQLEXPRESS;Database=BlogStoreDb;Integrated Security=True;TrustServerCertificate=True;");
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Identity tabloları için gerekli olan konfigürasyon
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<About>()
                .HasMany(a => a.Sections)
                .WithOne(s => s.About)
                .HasForeignKey(s => s.AboutId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutSection> AboutSections { get; set; }
    }
}
