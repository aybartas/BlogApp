using BlogApp.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Client.APIServices.Interface
{
    public interface IBlogApiService
    {
        Task<List<BlogListModel>> GetAll();

    }
}
