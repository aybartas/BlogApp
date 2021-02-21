using BlogApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Entities.DTO.CategoryDTO
{
    public class CategoryWithBlogCountDTO
    {
        public int BlogCount { get; set; }

        public Category Category { get; set; }

    }
}
