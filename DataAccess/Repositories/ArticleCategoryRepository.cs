using Core.Models;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ArticleCategoryRepository : Repository<ArticleCategory>, IArticleCategoryRepository
    {
        public ArticleCategoryRepository(BlogDbContext context) : base (context) 
        {
        }
    }
}
