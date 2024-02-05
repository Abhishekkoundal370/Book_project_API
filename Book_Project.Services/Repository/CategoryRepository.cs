using Book_Project.Model.Model;
using Book_Project.Services.Data;
using Book_Project.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Project.Services.Repository
{
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
       
    }
}
