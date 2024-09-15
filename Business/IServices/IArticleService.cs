using Core.Models;
using Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetAllArticlesAsync();
        Task<Article> GetArticleByIdAsync(int id);
        Task<int> AddArticleAsync(ArticleDto articleDto);
        Task UpdateArticleAsync(Article article);
        Task DeleteArticleAsync(int id);
        Task<IEnumerable<Article>> GetArticlesByAuthorAsync(int authorId);
    }
}
