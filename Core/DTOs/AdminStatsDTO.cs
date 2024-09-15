using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class AdminStatsDTO
    {
        public int TotalComments { get; set; }
        public int PendingComments { get; set; }
        public int RejectedComments { get; set; }
        public int TotalArticles { get; set; }
        public int PendingArticles { get; set; }
        public int RejectedArticles { get; set; }
    }
}
