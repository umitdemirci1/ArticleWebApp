using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ArticleDetailImageDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string AltText { get; set; }
        public string Caption { get; set; }
        public int Position { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
