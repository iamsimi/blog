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
    public class EditModel : PageModel
    {
        private readonly IblogManager _blgManager;

        public EditModel(IblogManager blgManager)
        {
            _blgManager = blgManager;
        }
        [BindProperty]
        public Article Article { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Article = _blgManager.GetOne(id);
            if (Article == null)
            {
                RedirectToPage("./Index");
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                var userEmail = User.FindFirst(ClaimTypes.Name).Value;

                _blgManager.Delete(id);
                _blgManager.Create(Article, userEmail);
            }
            catch (Exception)
            {
                RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");

        }
    }
}