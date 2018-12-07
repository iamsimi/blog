using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using blog.Data;
using blog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace blog.Pages
{
   [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IblogManager _blgManager;
        public CreateModel(IblogManager blgManager)
        {
            _blgManager = blgManager;
        }
        [BindProperty]
        public Article Article { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var userEmail = User.FindFirst(ClaimTypes.Name).Value;

            _blgManager.Create(Article, userEmail);
            return RedirectToPage("./Index");
        }
    }
}