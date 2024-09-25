
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class BlogDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
             : base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleImage> ArticleImages { get; set; }
        public DbSet<ArticleView> ArticleViews { get; set; }
        public DbSet<ArticleLike> ArticleLikes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ArticleComment> ArticleComments { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Article tablosu için sorgu filtresi
            modelBuilder.Entity<Article>().HasQueryFilter(a => !a.IsDeleted);

            // ArticleImage tablosu için sorgu filtresi
            modelBuilder.Entity<ArticleImage>().HasQueryFilter(ai => !ai.IsDeleted);

            // ArticleView tablosu için sorgu filtresi
            modelBuilder.Entity<ArticleView>().HasQueryFilter(av => !av.IsDeleted);

            // ArticleLike tablosu için sorgu filtresi
            modelBuilder.Entity<ArticleLike>().HasQueryFilter(al => !al.IsDeleted);

            // Category tablosu için sorgu filtresi
            modelBuilder.Entity<Category>().HasQueryFilter(c => !c.IsDeleted);

            // ArticleComment tablosu için sorgu filtresi
            modelBuilder.Entity<ArticleComment>().HasQueryFilter(ac => !ac.IsDeleted);

            // Tag tablosu için sorgu filtresi
            modelBuilder.Entity<Tag>().HasQueryFilter(t => !t.IsDeleted);

            // AppUser tablosu için sorgu filtresi
            modelBuilder.Entity<AppUser>().HasQueryFilter(u => !u.IsDeleted);

            // Article - AppUser (One-to-Many)
            modelBuilder.Entity<Article>()
                .HasOne(a => a.AppUser)
                .WithMany(u => u.Articles)
                .HasForeignKey(a => a.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Article - ArticleImage (One-to-Many)
            modelBuilder.Entity<Article>()
                .HasMany(a => a.ArticleImages)
                .WithOne(ai => ai.Article)
                .HasForeignKey(ai => ai.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Article - ArticleView (One-to-Many)
            modelBuilder.Entity<Article>()
                .HasMany(a => a.ArticleViews)
                .WithOne(av => av.Article)
                .HasForeignKey(av => av.ArticleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Article - ArticleLike (One-to-Many)
            modelBuilder.Entity<Article>()
                .HasMany(a => a.ArticleLikes)
                .WithOne(al => al.Article)
                .HasForeignKey(al => al.ArticleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Article - ArticleComment (One-to-Many)
            modelBuilder.Entity<Article>()
                .HasMany(a => a.ArticleComments)
                .WithOne(ac => ac.Article)
                .HasForeignKey(ac => ac.ArticleId)
                .OnDelete(DeleteBehavior.Restrict);

            // AppUser - ArticleComment (One-to-Many)
            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.ArticleComments)
                .WithOne(ac => ac.AppUser)
                .HasForeignKey(ac => ac.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // AppUser - ArticleView (One-to-Many)
            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.ArticleViews)
                .WithOne(av => av.AppUser)
                .HasForeignKey(av => av.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // AppUser - ArticleLike (One-to-Many)
            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.ArticleLikes)
                .WithOne(al => al.AppUser)
                .HasForeignKey(al => al.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Article - Category (Many-to-Many)
            modelBuilder.Entity<ArticleCategory>()
                .HasKey(ac => new { ac.ArticleId, ac.CategoryId });

            modelBuilder.Entity<ArticleCategory>()
                .HasOne(ac => ac.Article)
                .WithMany(a => a.ArticleCategories)
                .HasForeignKey(ac => ac.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ArticleCategory>()
                .HasOne(ac => ac.Category)
                .WithMany(c => c.ArticleCategories)
                .HasForeignKey(ac => ac.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Article - Tag (Many-to-Many)
            modelBuilder.Entity<ArticleTag>()
                .HasKey(at => new { at.ArticleId, at.TagId });

            modelBuilder.Entity<ArticleTag>()
                .HasOne(at => at.Article)
                .WithMany(a => a.ArticleTags)
                .HasForeignKey(at => at.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ArticleTag>()
                .HasOne(at => at.Tag)
                .WithMany(t => t.ArticleTags)
                .HasForeignKey(at => at.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed verilerini çağır
            SeedData.Seed(modelBuilder);

        }
    }
}
