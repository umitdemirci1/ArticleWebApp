using Core.Models.IEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ArticleTag : IEntityBase
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; } = null!;
        public int TagId { get; set; }
        public Tag Tag { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }
}
