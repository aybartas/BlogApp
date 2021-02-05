using BlogApp.Business.Interfaces;
using BlogApp.DataAccess.Interfaces;
using BlogApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Concrete
{
    public class BlogService: GenericService<Blog>, IBlogService
    {

        readonly IGenericDal<Blog> genericDal;
        
        public BlogService(IGenericDal<Blog> genericDal): base(genericDal)
        {
            this.genericDal = genericDal;
        }

        public async Task<List<Blog>> GetBlogsSortedByPublishedTime()
        {
            return await genericDal.GetAllWithDescendingOrder(I => I.PublishedTime);
        }
    }
}
