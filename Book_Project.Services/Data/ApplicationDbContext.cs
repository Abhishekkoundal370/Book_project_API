using Book_Project.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Project.Services.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base (options)
        { 
        }
        public DbSet<Covertype>Covertypes { get; set; }
        public DbSet<Category>Categories { get; set; }
    }
}
