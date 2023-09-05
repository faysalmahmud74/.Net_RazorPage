using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RajorPage.Data;
using RajorPage.Model;

namespace RajorPage.Movie
{
    public class DeleteModel : PageModel
    {
        private readonly RajorPage.Data.RazorPageContext _context;

        public DeleteModel(RajorPage.Data.RazorPageContext context)
        {
            _context = context;
        }

        [BindProperty]
      public MovieModel MovieModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var moviemodel = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);

            if (moviemodel == null)
            {
                return NotFound();
            }
            else 
            {
                MovieModel = moviemodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }
            var moviemodel = await _context.Movie.FindAsync(id);

            if (moviemodel != null)
            {
                MovieModel = moviemodel;
                _context.Movie.Remove(MovieModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
