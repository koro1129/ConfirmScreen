using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConfirmScreen.Models
{
    public class ConfirmScreenContext : DbContext
    {
        public ConfirmScreenContext (DbContextOptions<ConfirmScreenContext> options)
            : base(options)
        {
        }

        public DbSet<ConfirmScreen.Models.Movie> Movie { get; set; }
    }
}
