using BlogApp.Business.Interfaces;
using BlogApp.DataAccess.Interfaces;
using BlogApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Concrete
{
    public class CategoryService: GenericService<Category>, ICategoryService
    {
        readonly IGenericDal<Category> genericDal;

        readonly ICategoryDal categoryDal;

        public CategoryService(IGenericDal<Category> genericDal, ICategoryDal categoryDal) : base(genericDal)
        {
            this.genericDal = genericDal;
            this.categoryDal = categoryDal;
        }

        public Task<List<Category>> GetAllWithBlogCategories()
        {
            return categoryDal.GetAllWithBlogs();

        }
    }
}
