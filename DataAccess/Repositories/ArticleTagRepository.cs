using DataAccess.IRepository;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ArticleTagRepository : Repository<ArticleTag>, IArticleTagRepository
    {
        public ArticleTagRepository(BlogDbContext context) : base(context)
        {
        }
    }
}
