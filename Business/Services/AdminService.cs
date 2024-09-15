using Business.IServices;
using Core.DTOs;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AdminStatsDTO> GetAdminDashboardDataAsync()
        {
            var articles = _unitOfWork.Articles;
            var comments = _unitOfWork.ArticleComments;

            var stats = new AdminStatsDTO
            {
                TotalArticles = await articles.CountAsync(),
                PendingArticles = await articles.CountAsync(article => article.IsRejected == false && article.IsPublished == false),
                RejectedArticles = await articles.CountAsync(article => article.IsRejected == true),
                TotalComments = await comments.CountAsync(),
                PendingComments = await comments.CountAsync(comment => comment.IsRejected == false),
                RejectedComments = await comments.CountAsync(comment => comment.IsRejected == true)
            };

            return stats ?? new AdminStatsDTO();
        }
    }
}
