using Core.Models.IEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ArticleComment : IEntityBase
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsRejected { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; } = null!;
        public int ArticleId { get; set; }
        public Article Article { get; set; } = null!;
    }
}
