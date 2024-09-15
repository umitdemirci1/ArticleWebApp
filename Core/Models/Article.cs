using Core.Models.IEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Article : IEntityBase
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? CoverImageUrl { get; set; } // Kapak resmi için
        public bool IsDeleted { get; set; }
        public bool HasGallery { get; set; } = false; // Galeri olup olmadığını belirten bayrak
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; } = null!;
        public bool IsPublished { get; set; } = false;
        public bool IsRejected { get; set; } = false;
        
        public ICollection<ArticleImage> ArticleImages { get; set; } = new List<ArticleImage>();
        public ICollection<ArticleView> ArticleViews { get; set; } = new List<ArticleView>();
        public ICollection<ArticleLike> ArticleLikes { get; set; } = new List<ArticleLike>();
        public ICollection<ArticleComment> ArticleComments { get; set; } = new List<ArticleComment>();
        public ICollection<ArticleCategory> ArticleCategories { get; set; } = new List<ArticleCategory>();
        public ICollection<ArticleTag> ArticleTags { get; set; } = new List<ArticleTag>();
    }

}
