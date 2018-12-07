using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Data;
using blog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace blog.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IblogService _blgService;
        [BindProperty]
        public Article  Article { get; set; }

        public DetailsModel(IblogService blgService)
        {
            _blgService = blgService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                RedirectToPage("./Index");
            }

            Article =await  _blgService.GetOneArticle(id);
            if (Article == null)
            {
                RedirectToPage("./Index");
            }
            return Page();

        }
        
    }
}