using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IArticleService
    {
        Task AddArticleAsync(Article article);
        Task DeleteArticleAsync(int articleId);
        // Diğer metotlar burada tanımlanabilir
    }
}
