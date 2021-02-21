using BlogApp.Business.Interfaces;
using BlogApp.DataAccess.Interfaces;
using BlogApp.Entities.Concrete;
using BlogApp.Entities.DTO.BlogDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Concrete
{
    public class BlogService: GenericService<Blog>, IBlogService
    {
        readonly IGenericDal<BlogCategory> blogCategoryDal;

        readonly IGenericDal<Blog> genericDal;
        
        public BlogService(IGenericDal<Blog> genericDal, IGenericDal<BlogCategory> blogCategoryDal) : base(genericDal)
        {
            this.genericDal = genericDal;
            this.blogCategoryDal = blogCategoryDal;
        }

        public async Task<List<Blog>> GetBlogsSortedByPublishedTime()
        {
            return await genericDal.GetAllWithDescendingOrder(I => I.PublishedTime);
        }

        public async Task RemoveCategoryFromBlog(BlogCategoryDto blogCategoryDto)
        {

            var categoryToDeleteFromBlog =  await blogCategoryDal.GetByFilter(I => I.BlogId == blogCategoryDto.BlogId && I.CategoryId == blogCategoryDto.CategoryId);
            if(categoryToDeleteFromBlog != null)
            {
                await blogCategoryDal.Delete(categoryToDeleteFromBlog);
            }
        }

        public async Task AddCategoryToBlog(BlogCategoryDto blogCategoryDto)
        {

            var categoryToAddToBlog =  await blogCategoryDal.GetByFilter(I => I.CategoryId == blogCategoryDto.CategoryId
            && I.BlogId == blogCategoryDto.BlogId); 

            if(categoryToAddToBlog == null)
            {
                await blogCategoryDal.Create(new BlogCategory { BlogId = blogCategoryDto.BlogId, CategoryId = blogCategoryDto.CategoryId });
            }
        }
    }
}
