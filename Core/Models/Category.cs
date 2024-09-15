using Core.Models.IEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Category : IEntityBase
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<ArticleCategory> ArticleCategories { get; set; } = new List<ArticleCategory>();
    }
}
