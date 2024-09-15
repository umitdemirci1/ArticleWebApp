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
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1,
                    UserName = "user1",
                    FirstName = "John",
                    LastName = "Doe",
                    NormalizedUserName = "USER1",
                    Email = "user1@example.com",
                    NormalizedEmail = "USER1@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Password123!"),
                    SecurityStamp = string.Empty,
                    IsDeleted = false
                },
                new AppUser
                {
                    Id = 2,
                    UserName = "user2",
                    FirstName = "Jane",
                    LastName = "Doe",
                    NormalizedUserName = "USER2",
                    Email = "user2@example.com",
                    NormalizedEmail = "USER2@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Password123!"),
                    SecurityStamp = string.Empty,
                    IsDeleted = false
                },
                new AppUser
                {
                    Id = 3,
                    UserName = "user3",
                    FirstName = "Mark",
                    LastName = "Doe",
                    NormalizedUserName = "USER3",
                    Email = "user3@example.com",
                    NormalizedEmail = "USER2@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Password123!"),
                    SecurityStamp = string.Empty,
                    IsDeleted = false
                },
                new AppUser
                {
                    Id = 4,
                    UserName = "user4",
                    FirstName = "Hans",
                    LastName = "Doe",
                    NormalizedUserName = "USER4",
                    Email = "user4@example.com",
                    NormalizedEmail = "USER2@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Password123!"),
                    SecurityStamp = string.Empty,
                    IsDeleted = false
                },
                 new AppUser
                 {
                     Id = 5,
                     UserName = "user5",
                     FirstName = "Marry",
                     LastName = "Doe",
                     NormalizedUserName = "USER5",
                     Email = "user5@example.com",
                     NormalizedEmail = "USER2@EXAMPLE.COM",
                     EmailConfirmed = true,
                     PasswordHash = hasher.HashPassword(null, "Password123!"),
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
                    AppUserId = 1,
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
                    AppUserId = 2,
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
                    AppUserId = 1,
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
                    AppUserId = 2,
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
                    AppUserId = 1,
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

            modelBuilder.Entity<IdentityRole<int>>().HasData(
               new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
               new IdentityRole<int> { Id = 2, Name = "Author", NormalizedName = "AUTHOR" },
               new IdentityRole<int> { Id = 3, Name = "User", NormalizedName = "USER" }
           );

            // Seed data for UserRoles
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
               new IdentityUserRole<int> { UserId = 1, RoleId = 1 }, // Admin User as Admin
               new IdentityUserRole<int> { UserId = 2, RoleId = 2 }, // Author User as Author
               new IdentityUserRole<int> { UserId = 3, RoleId = 3 }, // Regular User as User
               new IdentityUserRole<int> { UserId = 4, RoleId = 3 }, // John Doe as User
               new IdentityUserRole<int> { UserId = 5, RoleId = 3 }  // Jane Doe as User
           );
            // Diğer seed verileri buraya eklenebilir...
        }
    }
}
