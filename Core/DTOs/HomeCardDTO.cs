using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class HomeCardDto
    {
        public HomeCardArticleDto Article { get; set; }
        public HomeCardAppUserDto AppUser { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
    }
}
