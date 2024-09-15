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
        public int AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
    }
}
