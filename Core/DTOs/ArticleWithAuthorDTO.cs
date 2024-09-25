using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ArticleWithAuthorDTO
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorFullName { get; set; }
    }
}
