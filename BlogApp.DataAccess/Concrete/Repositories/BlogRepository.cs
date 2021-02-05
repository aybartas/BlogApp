
using BlogApp.DataAccess.Concrete.Context;
using BlogApp.DataAccess.Interfaces;
using BlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccess.Concrete.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogDal
    {
        
    }
}
