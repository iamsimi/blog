using blog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.Services
{
    public interface IblogService
    {
        Task<List<Article>> GetAllArticles();
        Task <Article> GetOneArticle(int id);
    }
}
