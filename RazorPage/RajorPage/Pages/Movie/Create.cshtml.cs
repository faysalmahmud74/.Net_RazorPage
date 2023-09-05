using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RajorPage.Data;
using RajorPage.Model;

namespace RajorPage.Movie
{
    public class CreateModel : PageModel
    {
        private readonly RajorPage.Data.RazorPageContext _context;

        public CreateModel(RajorPage.Data.RazorPageContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MovieModel MovieModel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Movie == null || MovieModel == null)
            {
                return Page();
            }

            _context.Movie.Add(MovieModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
