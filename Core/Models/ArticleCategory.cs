using Core.Models.IEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ArticleCategory : IEntityBase
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }
}
