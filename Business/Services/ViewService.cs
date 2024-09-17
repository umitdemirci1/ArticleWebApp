using Business.IServices;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ViewService : IViewService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ViewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<int> CountArticleViewsAsync(int articleId)
        {
            return _unitOfWork.ArticleViews.CountAsync(v => v.ArticleId == articleId);
        }
    }
}
