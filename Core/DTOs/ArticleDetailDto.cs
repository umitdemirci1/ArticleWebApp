using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ArticleDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool HasGallery { get; set; }
        public IEnumerable<ArticleDetailImageDto> articleImages { get; set; }
        public IEnumerable<ArticleComment> Comments { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
        public bool IsLiked { get; set; } = false;
        public int UserId { get; set; }
        public string AuthorFullName { get; set; }
    }
}
