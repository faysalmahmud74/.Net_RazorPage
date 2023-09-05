using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RajorPage.Model;

namespace RajorPage.Data
{
    public class RazorPageContext : DbContext
    {
        public RazorPageContext (DbContextOptions<RazorPageContext> options)
            : base(options)
        {
        }

        public DbSet<RajorPage.Model.MovieModel> Movie { get; set; } = default!;
    }
}
