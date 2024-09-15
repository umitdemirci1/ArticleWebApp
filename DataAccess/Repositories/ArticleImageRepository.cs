using Core.Models;
using DataAccess.IRepository;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ArticleImageRepository : Repository<ArticleImage>, IArticleImageRepository
    {
        public ArticleImageRepository(BlogDbContext context) : base(context)
        {
        }
    }
    }
