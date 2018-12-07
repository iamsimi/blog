using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using blog.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace blog.Services
{
    public class BlogManager : IblogManager
    {
        private readonly ApplicationDbContext _db;       
        public BlogManager(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Create(Article articleToCreate, string email)
        {
            var author = _db.Authors.FirstOrDefault(m => m.Email == email);
            HttpUtility.HtmlEncode(articleToCreate.Content).Replace("\n", "<br/>");

            var article = new Article
            {
                Title = articleToCreate.Title,
                Content = articleToCreate.Content,
                datePublished = DateTime.Now.ToShortDateString(),
                Author = author,
                Tags = articleToCreate.Tags
            };

            _db.Articles.Add(article);
            _db.SaveChanges();
        }

        public void Delete(int? id)
        {
            var article = _db.Articles.FirstOrDefault(m => m.id == id);
            _db.Articles.Remove(article);
            _db.SaveChanges();
        }

        public void Edit(Article articleToEdit, int id)
        {
            articleToEdit.id = id;
            _db.Entry(articleToEdit).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public Article GetOne(int? id)
        {
            var article = _db.Articles.FirstOrDefault(m => m.id == id);
            return article; 
        }

    }
}
