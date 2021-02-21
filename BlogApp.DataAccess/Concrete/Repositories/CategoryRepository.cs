using BlogApp.DataAccess.Concrete.Context;
using BlogApp.DataAccess.Interfaces;
using BlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccess.Concrete.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryDal
    {
        public async Task<List<Category>> GetAllWithBlogs()
        {
            using var context = new BlogAppContext();
            return await  context.Categories.OrderByDescending(I => I.Id).Include(I => I.BlogCategories)
                .Include(I => I.SubCategories).
                ToListAsync();

        }
    }
}
