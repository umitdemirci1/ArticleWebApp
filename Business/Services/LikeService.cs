using Business.IServices;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LikeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<int> CountArticleLikeAsync(int articleId)
        {
            return _unitOfWork.ArticleLikes.CountAsync(x => x.ArticleId == articleId);
        }
    }
}
