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
    public class DetailsModel : PageModel
    {
        private readonly RajorPage.Data.RazorPageContext _context;

        public DetailsModel(RajorPage.Data.RazorPageContext context)
        {
            _context = context;
        }

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
    }
}
