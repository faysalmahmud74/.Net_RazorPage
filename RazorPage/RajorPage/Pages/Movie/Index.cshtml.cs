using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RajorPage.Data;
using RajorPage.Model;

namespace RajorPage.Movie
{
    public class IndexModel : PageModel
    {
        private readonly RajorPage.Data.RazorPageContext _context;

        public IndexModel(RajorPage.Data.RazorPageContext context)
        {
            _context = context;
        }

        public IList<MovieModel> MovieModel { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

       /* public async Task OnGetAsync()
        {
            if (_context.Movie != null)
            {
                MovieModel = await _context.Movie.ToListAsync();
            }
        }*/

        public async Task OnGetAsync()
        {
            var Movie = from m in _context.Movie
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                Movie = Movie.Where(s => s.Title.Contains(SearchString));
            }

            MovieModel = await Movie.ToListAsync();
        }
    }
}
