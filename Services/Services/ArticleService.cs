using DataAccess.IRepository;
using Entities;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddArticleAsync(Article article)
        {
            await _unitOfWork.Articles.AddAsync(article);
            await _unitOfWork.SaveChangesAsync(); // Değişiklikleri kaydet
        }

        public async Task DeleteArticleAsync(int articleId)
        {
            await _unitOfWork.Articles.DeleteAsync(articleId);
            await _unitOfWork.SaveChangesAsync(); // Değişiklikleri kaydet
        }
    }
}
