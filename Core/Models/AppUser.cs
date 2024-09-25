using Core.Models.IEntity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class AppUser : IdentityUser<Guid>, IEntityBase
    {
        public bool IsDeleted { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        public ICollection<ArticleView> ArticleViews { get; set; } = new List<ArticleView>();
        public ICollection<ArticleLike> ArticleLikes { get; set; } = new List<ArticleLike>();
        public ICollection<ArticleComment> ArticleComments { get; set; } = new List<ArticleComment>();
        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
