using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Seed data for AppUser
            var hasher = new PasswordHasher<AppUser>();

            var user1Id = Guid.NewGuid();
            var user2Id = Guid.NewGuid();
            var user3Id = Guid.NewGuid();
            var user4Id = Guid.NewGuid();
            var user5Id = Guid.NewGuid();

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = user1Id,
                    UserName = "user1",
                    FirstName = "John",
                    LastName = "Doe",
                    NormalizedUserName = "USER1",
                    Email = "user1@example.com",
                    NormalizedEmail = "USER1@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(new AppUser(), "Password123!"),
                    SecurityStamp = string.Empty,
                    IsDeleted = false
                },
                new AppUser
                {
                    Id = user2Id,
                    UserName = "user2",
                    FirstName = "Jane",
                    LastName = "Doe",
                    NormalizedUserName = "USER2",
                    Email = "user2@example.com",
                    NormalizedEmail = "USER2@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(new AppUser(), "Password123!"),
                    SecurityStamp = string.Empty,
                    IsDeleted = false
                },
                new AppUser
                {
                    Id = user3Id,
                    UserName = "user3",
                    FirstName = "Mark",
                    LastName = "Doe",
                    NormalizedUserName = "USER3",
                    Email = "user3@example.com",
                    NormalizedEmail = "USER3@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(new AppUser(), "Password123!"),
                    SecurityStamp = string.Empty,
                    IsDeleted = false
                },
                new AppUser
                {
                    Id = user4Id,
                    UserName = "user4",
                    FirstName = "Hans",
                    LastName = "Doe",
                    NormalizedUserName = "USER4",
                    Email = "user4@example.com",
                    NormalizedEmail = "USER4@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(new AppUser(), "Password123!"),
                    SecurityStamp = string.Empty,
                    IsDeleted = false
                },
                 new AppUser
                 {
                     Id = user5Id,
                     UserName = "user5",
                     FirstName = "Marry",
                     LastName = "Doe",
                     NormalizedUserName = "USER5",
                     Email = "user5@example.com",
                     NormalizedEmail = "USER5@EXAMPLE.COM",
                     EmailConfirmed = true,
                     PasswordHash = hasher.HashPassword(new AppUser(), "Password123!"),
                     SecurityStamp = string.Empty,
                     IsDeleted = false
                 }
            );

            // Seed data for Articles
            modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    Id = 1,
                    Title = "First Article",
                    Content = "This is the content of the first article.",
                    IsDeleted = false,
                    CoverImageUrl = "https://example.com/cover1.jpg",
                    HasGallery = true,
                    IsPublished = true,
                    AppUserId = user1Id,
                },
                new Article
                {
                    Id = 2,
                    Title = "Second Article",
                    Content = "This is the content of the second article.",
                    IsDeleted = false,
                    CoverImageUrl = "https://example.com/cover2.jpg",
                    HasGallery = false,
                    IsPublished = false,
                    AppUserId = user2Id,
                },
                new Article
                {
                    Id = 3,
                    Title = "Third Article",
                    Content = "This is the content of the third article.",
                    IsDeleted = false,
                    CoverImageUrl = "https://example.com/cover3.jpg",
                    HasGallery = true,
                    IsPublished = true,
                    AppUserId = user3Id,
                },
                new Article
                {
                    Id = 4,
                    Title = "Fourth Article",
                    Content = "This is the content of the fourth article.",
                    IsDeleted = false,
                    CoverImageUrl = "https://example.com/cover4.jpg",
                    HasGallery = false,
                    IsPublished = true,
                    AppUserId = user4Id,
                },
                new Article
                {
                    Id = 5,
                    Title = "Fifth Article",
                    Content = "This is the content of the fifth article.",
                    IsDeleted = false,
                    CoverImageUrl = "https://example.com/cover5.jpg",
                    HasGallery = true,
                    IsPublished = false,
                    AppUserId = user5Id,
                },
                new Article
                {
                    Id = 6,
                    Title = "Sixth Article",
                    Content = "This is the content of the sixth article.",
                    IsDeleted = false,
                    CoverImageUrl = "https://example.com/cover6.jpg",
                    HasGallery = false,
                    IsPublished = true,
                    AppUserId = user1Id,
                },
                new Article
                {
                    Id = 7,
                    Title = "Seventh Article",
                    Content = "This is the content of the seventh article.",
                    IsDeleted = false,
                    CoverImageUrl = "https://example.com/cover7.jpg",
                    HasGallery = true,
                    IsPublished = false,
                    AppUserId = user2Id,
                },
                new Article
                {
                    Id = 8,
                    Title = "Eighth Article",
                    Content = "This is the content of the eighth article.",
                    IsDeleted = false,
                    CoverImageUrl = "https://example.com/cover8.jpg",
                    HasGallery = false,
                    IsPublished = true,
                    AppUserId = user3Id,
                }
            );

            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    TagId = 1,
                    Name = "AI",
                    IsDeleted = false
                },
                new Tag
                {
                    TagId = 2,
                    Name = "Machine Learning",
                    IsDeleted = false
                },
                new Tag
                {
                    TagId = 3,
                    Name = "COVID-19",
                    IsDeleted = false
                }
            );

            modelBuilder.Entity<Category>().HasData(
                  new Category { CategoryId = 1, Name = "Technology", IsDeleted = false },
                  new Category { CategoryId = 2, Name = "Science", IsDeleted = false },
                  new Category { CategoryId = 3, Name = "Health", IsDeleted = false }
            );

            var adminRoleId = Guid.NewGuid();
            var authorRoleId = Guid.NewGuid();
            var userRoleId = Guid.NewGuid();

            modelBuilder.Entity<IdentityRole<Guid>>().HasData(
               new IdentityRole<Guid> { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
               new IdentityRole<Guid> { Id = authorRoleId, Name = "Author", NormalizedName = "AUTHOR" },
               new IdentityRole<Guid> { Id = userRoleId, Name = "User", NormalizedName = "USER" }
           );

            // Seed data for UserRoles
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
               new IdentityUserRole<Guid> { UserId = user1Id, RoleId = adminRoleId }, // Admin User as Admin
               new IdentityUserRole<Guid> { UserId = user2Id, RoleId = authorRoleId }, // Author User as Author
               new IdentityUserRole<Guid> { UserId = user3Id, RoleId = userRoleId }, // Regular User as User
               new IdentityUserRole<Guid> { UserId = user4Id, RoleId = userRoleId }, // John Doe as User
               new IdentityUserRole<Guid> { UserId = user5Id, RoleId = userRoleId }  // Jane Doe as User
           );
            // Diğer seed verileri buraya eklenebilir...
        }
    }
}
