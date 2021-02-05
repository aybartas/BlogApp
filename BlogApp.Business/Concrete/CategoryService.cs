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

        public CategoryService(IGenericDal<Category> genericDal): base(genericDal)
        {
            this.genericDal = genericDal;
        }

    }
}
