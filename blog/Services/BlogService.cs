using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Data;
using Microsoft.EntityFrameworkCore;

namespace blog.Services
{
    public class BlogService : IblogService
    {
        private readonly ApplicationDbContext _db;
        public BlogService(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<List<Article>> GetAllArticles()
        {
            return _db.Articles.AsNoTracking()
                .Include(b => b.Author)
                .ToListAsync();
        }

        public Task <Article> GetOneArticle(int id)
        {
            var article = _db.Articles
                .Include(m => m.Author)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.id == id);

            return article;
        }
    }
}
