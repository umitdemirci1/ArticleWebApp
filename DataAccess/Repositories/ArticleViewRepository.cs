using DataAccess.IRepository;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ArticleViewRepository : Repository<ArticleView>, IArticleViewRepository
    {
        public ArticleViewRepository(BlogDbContext context) : base(context)
        {
        }
    }
}
