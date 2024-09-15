using DataAccess.IRepository;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class ArticleLikeRepository : Repository<ArticleLike>, IArticleLikeRepository
    {
        public ArticleLikeRepository(BlogDbContext context) : base(context)
        {
        }
    }
}
