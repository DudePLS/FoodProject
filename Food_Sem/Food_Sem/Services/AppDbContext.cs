using Food_Sem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Sem.Services
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options )
            : base(options)
        {

        }

        public DbSet<Recipe> Recipes { get; set;}
    }
}
