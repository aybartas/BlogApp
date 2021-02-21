using BlogApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccess.Interfaces
{
   public interface ICategoryDal: IGenericDal<Category>
    {
        Task<List<Category>> GetAllWithBlogs();

    }
}
