﻿using BlogApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Interfaces
{
    public interface IBlogService: IGenericService<Blog>
    {
        Task<List<Blog>> GetBlogsSortedByPublishedTime();

    }
}
