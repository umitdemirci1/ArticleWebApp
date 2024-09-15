using Core.Models.IEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Tag : IEntityBase
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<ArticleTag> ArticleTags { get; set; } = new List<ArticleTag>();
    }
}
