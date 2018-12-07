using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Data;
using blog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace blog.Pages
{
  [Authorize]
    public class AdminModel : PageModel
    {
        private readonly IblogService _blgService;
        private readonly IblogManager _blgManager; 
        public AdminModel(IblogService service, IblogManager blgManager)
        {
            _blgService = service;
            _blgManager = blgManager;
        }

        [BindProperty]
        public IList<Article> Articles { get; set; }
        
        public async Task OnGetAsync()
        {
            Articles = await _blgService.GetAllArticles();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id != null)
            {
                try
                {
                    _blgManager.Delete(id);
                }
                catch (Exception)
                {
                    return RedirectToPage();
                }
            }

            return RedirectToPage();
        }
    }
}