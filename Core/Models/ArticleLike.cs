using Core.Models.IEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ArticleLike : IEntityBase
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public bool IsDeleted { get; set; }
        public int AppUserId { get; set; }
        public DateTime LikedAt { get; set; } = DateTime.Now;


        public Article Article { get; set; } = null!;
        public AppUser AppUser { get; set; } = null!;
    }

}
