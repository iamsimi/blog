using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Data;
using blog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace blog.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IblogService _blogService;
        public IndexModel(IblogService service)
        {
            _blogService = service;
        }
        [BindProperty]
       public IList<Article> Articles { get; set; }
        public async Task OnGetAsync()
        {
            Articles = await _blogService.GetAllArticles();
        }
    }
}
